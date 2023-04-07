using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.ViewComponents.AdminDashboard
{
    public class DashboardAuthorByComment : ViewComponent
    {
        private readonly CommentManager _commentManager;
        private readonly UserManager<AppUser> _userManager;

        public DashboardAuthorByComment(CommentManager commentManager, UserManager<AppUser> userManager)
        {
            _commentManager = commentManager;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.Name is null) return View();
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            var authorComments = _commentManager.GetCommentByBlogAuthor(appUser.Id);
            return View(authorComments);
        }
    }
}
