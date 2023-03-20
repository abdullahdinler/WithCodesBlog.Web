using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Migrations;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly AboutManager _aboutManager;
        private readonly AboutValidator _aboutValidator;
        private ValidationResult _validation;

        public AboutController(AboutManager aboutManager, AboutValidator aboutValidator, ValidationResult validation)
        {
            _aboutManager = aboutManager;
            _aboutValidator = aboutValidator;
            _validation = validation;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var about = _aboutManager.Get(1);
            if (about is null) return NotFound();

            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] About about, IFormFile ImageUri)
        {
            _validation = await _aboutValidator.ValidateAsync(about);
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
                about.ImageUri = "/images/" + fileName;
            }



            if (_validation.IsValid)
            {
                about.ImageUri = about.ImageUri;
                _aboutManager.Update(about);
                TempData["Durum"] = "Sitenin hakkımızda kısmı düzenlendi.";
                return RedirectToAction("Index","Category");
            }
            else
            {
                foreach (var error in _validation.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
    }
}
