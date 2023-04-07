using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WithCodesBlog.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Yazar")]
    public class DashboardController : Controller
    {
        private readonly BlogManager _blogManager;
        private readonly CategoryManager _categoryManager;
        
        private readonly UserManager<AppUser> _userManager;
        public DashboardController(BlogManager blogManager, CategoryManager categoryManager, UserManager<AppUser> userManager)
        {
            _blogManager = blogManager;
            _categoryManager = categoryManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity!.Name is null) return RedirectToAction("Index", "Login");
            var appUser = await _userManager.FindByNameAsync(User.Identity!.Name);


            ViewBag.BlogCount = _blogManager.GetAllList().Count;
            ViewBag.CategoryCount = _categoryManager.GetAllList().Count;
            ViewBag.AuthorCount = _userManager.Users.ToList().Count;
            ViewBag.AuthorBlogCount = _blogManager.GetAllList().Count(x => x.AppUserId == appUser.Id);
            return View();
        }

    }
}
