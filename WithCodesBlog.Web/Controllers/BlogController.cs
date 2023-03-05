using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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

        [Route("Blog/")]
        public async Task<IActionResult> AllBlog(int page = 1)
        {

            var values = await _blog.GetBlogWithCategoryList().ToPagedListAsync(page, 3);
            return View(values);
        }


        [HttpGet("{slug}")]
        public IActionResult Details(string slug)
        {
            var model = _blog.GetBlogBySlug(slug);
            if (model != null)
            {
                return View(model);
            }
            return NotFound();

        }
        [HttpGet("Karegori/{categoryName}")]
        public IActionResult BlogByCategoryList(string categoryName)
        {
            var model = _blog.BlogListByCategory(categoryName);
            if (model != null)
            {
                ViewBag.CategoryName = categoryName;
                return View(model);
            }
            return NotFound();
        }

    }
}
