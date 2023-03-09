using AutoMapper;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WithCodesBlog.Web.UI.ViewModels;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace WithCodesBlog.Web.UI.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly CommentManager _comment;
        private readonly CommentValidator _validator;
        private ValidationResult _validation;
        private readonly IMapper _mapper;

        public CommentController(CommentManager comment, CommentValidator validator, IMapper mapper)
        {
            _comment = comment;
            _validator = validator;
            _mapper = mapper;
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CommentAdd([FromForm] CommentViewModel viewModel)
        {
            var comment = _mapper.Map<Comment>(viewModel);
            var returnUrl = viewModel.ReturnUrl ?? Url.Action("Index", "Blog");
            _validation = _validator.Validate(comment);
            if (_validation.IsValid)
            {
                comment.BlogId = viewModel.BlogId;
                comment.Status = true;
                comment.SendingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                TempData["Alert"] = "Yorum başarılı bir şekilde yapıldı.";
                _comment.Add(comment);
                return Redirect(returnUrl!);
                
            }
            else
            {
                foreach (var error in _validation.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return Redirect(returnUrl!);
        }
    }
}
