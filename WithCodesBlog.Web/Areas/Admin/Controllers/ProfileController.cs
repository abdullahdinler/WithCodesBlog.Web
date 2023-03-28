using AutoMapper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WithCodesBlog.Web.UI.Areas.Admin.ViewModels;

namespace WithCodesBlog.Web.UI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public ProfileController(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity!.Name is null) return RedirectToAction("Index", "Login");

            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(appUser);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile([Bind("UserName,NameSurname,Email,ImageUri")] ProfileViewModel model, IFormFile? ImageUri)
        {

            if (ModelState.IsValid)
            {
                if (User.Identity!.Name is null) return RedirectToAction("Index", "Login");
                var appUser = await _userManager.FindByNameAsync(User.Identity!.Name);

                if (appUser == null)
                {
                    return NotFound();
                }

                if (ImageUri != null)
                {
                    // ismin benzersiz olması için guid kullanıldı
                    var uniqueId = Guid.NewGuid();
                    var fileName = uniqueId + "_" + ImageUri.FileName;

                    // Dosyanın kaydedilecek yolu belirliyoruz
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                    // Stream adında FileStream nesnesi oluşturduk burada alınan yol ve oluştuma modu ile dosya resim ekleme işlemi yapıldı.
                    await using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await ImageUri.CopyToAsync(stream);
                    }

                    // Veri tabanına kaydedilecek yol verildi.
                    appUser.ImageUri = "/images/" + fileName;
                }

                appUser.UserName = model.UserName;
                appUser.NameSurname = model.NameSurname;
                appUser.Email = model.Email;

                var result = await _userManager.UpdateAsync(appUser);
                if (result.Succeeded)
                {
                    TempData["Alert"] = "Güncelleme başarılı bir şekilde yapıldı.";
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword([Bind("OldPassword,NewPassword,ConfirmNewPassword")] PasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (User.Identity!.Name is null) return RedirectToAction("Index", "Login");
                    var appUser = await _userManager.FindByNameAsync(User.Identity!.Name);
                    if (appUser == null)
                    {
                        return NotFound();
                    }

                    var result = await _userManager.ChangePasswordAsync(appUser, model.OldPassword, model.NewPassword);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            TempData["AlertError"] = "Şifreniz güncellerken bir hata oluştu.";
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return RedirectToAction(nameof(Index));
                    }

                    await _signInManager.RefreshSignInAsync(appUser);
                    TempData["Alert"] = "Şifreniz başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                TempData["AlertError"] = "Şifreniz güncellerken bir hata oluştu.";
                return BadRequest(e.Message);
            }

        }
    }
}
