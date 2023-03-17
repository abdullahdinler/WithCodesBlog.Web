using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata;
using AutoMapper;
using BusinessLayer.ValidationRules;
using Microsoft.EntityFrameworkCore;
using WithCodesBlog.Web.UI.Areas.Admin.ViewModels;
using X.PagedList;
using DataAccessLayer.Migrations;
using FluentValidation.Results;

namespace WithCodesBlog.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AuthorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AppUserManager _user;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private AppUserValidator _validator;

        public AuthorController(AppUserManager user, UserManager<AppUser> userManager, IMapper mapper, AppUserValidator validator, RoleManager<AppRole> roleManager)
        {
            _user = user;
            _userManager = userManager;
            _mapper = mapper;
            _validator = validator;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(string search, int? page)
        {
            int _page = page ?? 1;
            string _search = search ?? "";
            if (_search != null)
            {
                var authorList = await _user.Search(_search).ToPagedListAsync(_page, 5);
                return View(authorList);
            }
            var values = await _userManager.Users.ToPagedListAsync(_page, 5);

            return View(values);

        }

        [HttpGet]
        public async Task<IActionResult> NewAuthor()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewAuthor([FromForm] AppUserViewModel viewModel, IFormFile ImageUri)
        {
            // mapper ile viewmodel appuser cevrildi
            var appUser = _mapper.Map<AppUser>(viewModel);



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
                viewModel.ImageUri = "/images/" + fileName;
            }

            ValidationResult validation = await _validator.ValidateAsync(appUser);
            appUser.ImageUri = viewModel.ImageUri;

            if (validation.IsValid)
            {
                TempData["Durum"] = "Yazar başarılı bir şekilde oluşturuldu";

                // burada yeni bir kullanıcı oluşturuldu.
                var result = await _userManager.CreateAsync(appUser, viewModel.PasswordHash);

                if (result.Succeeded)
                {
                    if (viewModel.IsAdmin == "Admin")
                    {
                        await _userManager.AddToRoleAsync(appUser, "Admin");
                    }
                    else if (viewModel.IsAdmin == "Yazar")
                    {
                        await _userManager.AddToRoleAsync(appUser, "Yazar");
                    }
                    return RedirectToAction(nameof(Index));
                    //return RedirectToAction("AssignRole", "Author", new { id = appUser.Id });
                }

            }
            else
            {
                foreach (var error in validation.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            var appUser = await _userManager.FindByIdAsync(id.ToString());
            if (appUser != null)
            {
                var result = await _userManager.DeleteAsync(appUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Author");

                }
            }

            return RedirectToAction("Index", "Author");

        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            var roles = await _roleManager.Roles.ToListAsync();
            TempData["userId"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);
            List<AssignRoleViewModel> models = new();
            foreach (var role in roles)
            {
                AssignRoleViewModel model = new();
                model.RoleId = role.Id;
                model.RoleName = role.Name;
                model.Exists = userRoles.Contains(role.Name);
                models.Add(model);

            }

            return View(models);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRole([FromForm] List<AssignRoleViewModel> model)
        {
            var userId = (int)TempData["userId"];
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

            foreach (var item in model)
            {

                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("Index");
        }


    }
}
