using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        [Route("Error404/")]
        public IActionResult Error404(int code)
        {
            return View();
        }

        [Route("Error403/")]
        public IActionResult Error403()
        {
            return View();
        }

    }
}
