using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly CategoryManager _category;

        public CategoryController(CategoryManager category)
        {
            _category = category;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
