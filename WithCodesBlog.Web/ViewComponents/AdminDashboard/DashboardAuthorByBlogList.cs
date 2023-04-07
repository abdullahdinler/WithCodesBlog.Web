using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace WithCodesBlog.Web.UI.ViewComponents.AdminDashboard
{
    public class DashboardAuthorByBlogList : ViewComponent
    {
        private readonly BlogManager _blogManager;
        private readonly UserManager<AppUser> _userManager;

        public DashboardAuthorByBlogList(BlogManager blogManager, UserManager<AppUser> userManager)
        {
            _blogManager = blogManager;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            if (User.Identity!.Name is null) return View();
            var appUser = await _userManager.FindByNameAsync(User.Identity!.Name);
            
            var authorBlogs = _blogManager.BlogListByAuthor(appUser.UserName);
            return View(authorBlogs);
        }
    }
}
