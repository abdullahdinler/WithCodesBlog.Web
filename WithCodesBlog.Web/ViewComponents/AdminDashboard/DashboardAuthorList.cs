using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.ViewComponents.AdminDashboard
{
    public class DashboardAuthorList : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardAuthorList(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var authorList = _userManager.Users.ToList();
            return View(authorList);
        }
    }
}
