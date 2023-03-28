using Microsoft.AspNetCore.Mvc;
using WithCodesBlog.Web.UI.Areas.Admin.ViewModels;

namespace WithCodesBlog.Web.UI.ViewComponents.AuthorViewComponent
{
    public class PasswordUpdate : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           PasswordViewModel password = new PasswordViewModel();
            return View(password);
        }

    }
}
