using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.ViewComponents.CommentViewComponent
{
    public class CommentList : ViewComponent
    {
        private readonly CommentManager _comment;

        public CommentList(CommentManager comment)
        {
            _comment = comment;
        }

        public IViewComponentResult Invoke(string slug)
        {
            var comments = _comment.GetAllList(slug);
            
            if (comments != null)
            {
                return View(comments);
            }

            return View();
        }
    }
}
