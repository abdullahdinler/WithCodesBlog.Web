using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WithCodesBlog.Web.UI.Areas.Admin.ViewModels;
using X.PagedList;
using DataAccessLayer.Migrations;

namespace WithCodesBlog.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AuthorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AppUserManager _user;
        private readonly UserManager<AppUser> _userManager;

        public AuthorController(AppUserManager user, UserManager<AppUser> userManager, IMapper mapper)
        {
            _user = user;
            _userManager = userManager;
            _mapper = mapper;
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
            var values =  await _userManager.Users.ToPagedListAsync(_page, 5);
            return View(values);
        }

        [HttpGet]
        public IActionResult NewAuthor()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewAuthor(AppUserViewModel viewModel, IFormFile ImageUri)
        {
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

            viewModel.ImageUri = "/adminpanel/dist/img/user1-128x128.jpg";

            // mapper ile viewmodel appuser cevrildi
            var appUser = _mapper.Map<AppUser>(viewModel);

            // validation işlemi true ise işlemi yap
            if (ModelState.IsValid)
            {
                // burada yeni bir kullanıcı oluşturuldu.
                var result = await _userManager.CreateAsync(appUser, viewModel.PasswordHash);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Author");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }

            }

            return View();
        }
    }
}
