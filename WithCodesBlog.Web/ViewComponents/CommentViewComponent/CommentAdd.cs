using AutoMapper;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using WithCodesBlog.Web.UI.ViewModels;

namespace WithCodesBlog.Web.UI.ViewComponents.CommentViewComponent
{
    public class CommentAdd : ViewComponent
    {
        private readonly Comment _comment;
        private readonly IMapper _mapper;

        public CommentAdd(Comment comment, IMapper mapper)
        {
            _mapper = mapper;
            _comment = comment;
        }

        public IViewComponentResult Invoke(int? id)
        {
            var comment = _mapper.Map<CommentViewModel>(_comment);
            TempData["id"] = id;
            return View(comment);
        }
    }
}
