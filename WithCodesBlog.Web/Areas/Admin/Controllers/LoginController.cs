using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WithCodesBlog.Web.UI.Areas.Admin.ViewModels;

namespace WithCodesBlog.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _sign;

        public LoginController(SignInManager<AppUser> sign)
        {
            _sign = sign;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _sign.PasswordSignInAsync(model.UserName, model.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["ErrorMessage"] = "Kullanıcı adı veya şifre hatalı.";
                }
            }
            return View(model);
        }

    }
}
