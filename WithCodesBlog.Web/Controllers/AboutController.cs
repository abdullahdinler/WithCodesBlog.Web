using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.Controllers
{
    public class AboutController : Controller
    {
        private readonly AboutManager _aboutManager;

        public AboutController(AboutManager aboutManager)
        {
            _aboutManager = aboutManager;
        }

        [Route("Hakkimizda/")]
        public IActionResult Index()
        {
            var about = _aboutManager.GetAllList()!.FirstOrDefault();
            if (about != null)
            {
                return View(about);
            }

            return NotFound();
        }
    }
}
