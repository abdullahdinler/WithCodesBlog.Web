
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace WithCodesBlog.Web.UI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly CategoryManager _categoryManager;
        private readonly CategoryValidator _validator;

        public CategoryController(CategoryManager categoryManager, CategoryValidator validator)
        {
            this._categoryManager = categoryManager;
            _validator = validator;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int _page = page ?? 1;
            var categories = await _categoryManager.CategoriesWithBlogs().ToPagedListAsync(_page, 5);
            if (categories != null)
            {
                return View(categories);
            }

            return NotFound();
        }


        public IActionResult Satatus(int id)
        {
            var category = _categoryManager.Get(id);
            if (category != null)
            {
                category.Status = !category.Status;
                _categoryManager.Update(category);
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult NewCategory()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewCategory([FromForm] Category category)
        {
            ValidationResult vr = await _validator.ValidateAsync(category);
            if (vr.IsValid)
            {
                category.Description = null;
                //category.Status = false;
                _categoryManager.Add(category);
                TempData["Durum"] = "Kategori başarılı bir şekilde eklendi.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in vr.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
    }
}
