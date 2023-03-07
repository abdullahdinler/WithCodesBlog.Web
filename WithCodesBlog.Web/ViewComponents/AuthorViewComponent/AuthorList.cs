using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.ViewComponents.AuthorViewComponent
{
    public class AuthorList : ViewComponent
    {
        private readonly AppUserManager _appUser;

        public AuthorList(AppUserManager appUser)
        {
            _appUser = appUser;
        }

        public IViewComponentResult Invoke()
        {
            var authors = _appUser.GetAllList();
            return View(authors);
        }
    }
}
