using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace WithCodesBlog.Web.UI.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private readonly NotificationManager _notificationManager;

        public NotificationController(NotificationManager notificationManager)
        {
            _notificationManager = notificationManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int? page)
        {
            int _page = page ?? 1;
            var notifications = await _notificationManager.GetAllList().ToPagedListAsync(_page, 5);
            return View(notifications);
        }
    }
}
