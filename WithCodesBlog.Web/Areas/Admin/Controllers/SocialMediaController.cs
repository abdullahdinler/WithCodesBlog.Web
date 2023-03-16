using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly SocialMediaManager _mediaManager;
        private readonly SocialMediaValidator _validator;

        public SocialMediaController(SocialMediaManager mediaManager, SocialMediaValidator validator)
        {
            _mediaManager = mediaManager;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var socialMediae = _mediaManager.GetAllList();
            if (socialMediae != null)
            {
                return View(socialMediae);
            }

            return NotFound();
        }


        public IActionResult Status(int id)
        {
            var socialMedia = _mediaManager.Get(id);
            if (socialMedia != null)
            {
                socialMedia.Status = !socialMedia.Status;
                _mediaManager.Update(socialMedia);
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var socialMedia = _mediaManager.Get(id);
            if (socialMedia != null)
            {
                return View(socialMedia);
            }

            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] SocialMedia media)
        {
            ValidationResult vr = await _validator.ValidateAsync(media);
            if (vr.IsValid)
            {
                _mediaManager.Update(media);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in vr.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View(media);
        }

    }
}
