using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.ViewComponents.BlogViewComponent
{
    public class SearchBlog:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
