using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace WithCodesBlog.Web.UI.Controllers
{
    [AllowAnonymous]
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
        public async Task<IActionResult> AllBlog(string search, int? page)
        {
            int _page = page ?? 1;
            string _search = search ?? "";
            if (_search != null)
            {
                var result = await _blog.Search(_search).ToPagedListAsync(_page, 10);
                return View(result);
            }
            var values = await _blog.GetBlogWithCategoryList().ToPagedListAsync(_page, 10);
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
        [HttpGet("Kategori/{categoryName}")]
        public async Task<IActionResult> BlogByCategoryList(string categoryName, int page = 1)
        {
            var model = await _blog.BlogListByCategory(categoryName).ToPagedListAsync(page, 10);
            if (model != null)
            {
                ViewBag.CategoryName = categoryName;
                return View(model);
            }
            return NotFound();
        }

        [HttpGet("Yazar/{authorName}")]
        public async Task<IActionResult> BlogByAuthorList(string authorName, int page = 1)
        {
            var model = await _blog.BlogListByAuthor(authorName).ToPagedListAsync(page, 10);
            if (model != null)
            {
                ViewBag.AuthorName = authorName;
                return View(model);
            }
            return NotFound();
        }

        [HttpGet("Hashtag/{hashtagName}")]
        public async Task<IActionResult> BlogByHashtagList(string hashtagName, int page = 1)
        {
          
            var model = await _blog.BlogListByHashtag(hashtagName).ToPagedListAsync(page, 10);
            if (model != null)
            {
                ViewBag.hashtagName = hashtagName;
                return View(model);
            }
            return NotFound();
        }

    }
}
