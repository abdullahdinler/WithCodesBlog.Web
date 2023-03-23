using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace WithCodesBlog.Web.UI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class CommentsController : Controller
    {
        private readonly CommentManager _comment;
        private readonly UserManager<AppUser> _userManager;
        private readonly CommentAnswerManager _answerManager;
        private readonly CommentAnswerValidator _validator;

        public CommentsController(CommentManager comment, UserManager<AppUser> userManager, CommentAnswerManager answerManager, CommentAnswerValidator validator)
        {
            _comment = comment;
            _userManager = userManager;
            _answerManager = answerManager;
            _validator = validator;
        }

        public async Task<IActionResult> Index(int? page)
        {
            try
            {
                if (User.Identity?.Name == null) return NotFound();
                var user = await _userManager.FindByNameAsync(User.Identity?.Name);
                var userId = await _userManager.GetUserIdAsync(user);

                if (_comment == null) return NotFound();

                int _page = page ?? 1;
                var comments = await _comment.GetCommentByBlogAuthor(int.Parse(userId)).ToPagedListAsync(_page, 10);
                return View(comments);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var comment = _comment.Get(id);
                if (comment == null) return NotFound();

                _comment.Delete(comment);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        public IActionResult Status(int id)
        {
            try
            {
                var comment = _comment.Get(id);
                if (comment == null) return NotFound();

                comment.Status = !comment.Status;
                _comment.Update(comment);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Answer(int id)
        {
            try
            {
                var comment = _comment.Get(id);
                if (comment == null) return NotFound();

                return View(comment);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Answer([FromForm] CommentAnswer answer)
        {
            try
            {
                ValidationResult vr = await _validator.ValidateAsync(answer);
                if (vr.IsValid)
                {
                    answer.Status = true;
                    return View();
                }


            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }


    }
}
