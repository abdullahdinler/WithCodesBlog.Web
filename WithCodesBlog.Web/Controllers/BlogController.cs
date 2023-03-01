using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogManager _blog;

        public BlogController(BlogManager blog)
        {
            _blog = blog;
        }

        public IActionResult Index()
        {

            var values = _blog.GetBlogWithCategoryList();
            return View(values);
        }
    }
}
