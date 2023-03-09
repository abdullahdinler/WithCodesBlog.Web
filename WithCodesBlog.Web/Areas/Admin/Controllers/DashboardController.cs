using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
