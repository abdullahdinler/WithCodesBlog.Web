using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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

        public async Task<IActionResult> AllBlog(int page = 1)
        {

            var values = await _blog.GetBlogWithCategoryList().ToPagedListAsync(page, 3);
            return View(values);
        }

        
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _blog.GetBlogById(id);
            return View(model);
        }

        //[HttpGet("{slug}")]
        //public IActionResult Details(string slug)
        //{
        //    var model = _blog.GetBlogBySlug(slug);
        //    return View(model);
        //}


    }
}
