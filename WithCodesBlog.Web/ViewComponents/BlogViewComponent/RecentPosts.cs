using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.ViewComponents.Blog
{
    public class RecentPosts:ViewComponent
    {
        private readonly BlogManager _blog;

        public RecentPosts(BlogManager blog)
        {
            _blog = blog;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await Task.Run(() =>
            {
                return _blog.GetAllList().OrderByDescending(x => x.CreateDate).Take(3).ToList();
            });

            return View(result);
        }

    }
}
