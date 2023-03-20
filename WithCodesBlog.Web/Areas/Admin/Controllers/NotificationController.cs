using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace WithCodesBlog.Web.UI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private readonly NotificationManager _notificationManager;
        private readonly NotificationValidator _validator;
        private ValidationResult _result;

        public NotificationController(NotificationManager notificationManager, NotificationValidator validator, ValidationResult result)
        {
            _notificationManager = notificationManager;
            _validator = validator;
            _result = result;
        }

       
        public async Task<IActionResult> Index(int? page)
        {
            int _page = page ?? 1;
            var notifications = await _notificationManager.GetAllList().ToPagedListAsync(_page, 5);
            return View(notifications);
        }


        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _notificationManager.Get(id);
                if (entity is null) return NotFound();

                _notificationManager.Delete(entity);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Send()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Send([FromForm] Notification notification)
        {
            try
            {
                _result = _validator.Validate(notification);
                if (_result.IsValid)
                {
                    notification.Status = true;
                    notification.SendingDate = DateTime.Parse( DateTime.Now.ToShortDateString());
                    _notificationManager.Add(notification);
                    TempData["Alert"] = "Bildirim başarılı bir şekilde gönderildi";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in _result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return View(notification);
        }


    }
}
