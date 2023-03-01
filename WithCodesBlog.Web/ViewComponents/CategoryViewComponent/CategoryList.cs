using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.ViewComponents.CategoryViewComponent
{
    public class CategoryList:ViewComponent
    {
        private readonly ICategoryDal _category;

        public CategoryList(ICategoryDal category)
        {
            _category = category;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await Task.Run(() => _category.GetAll());
            return View(result);
        }
    }
}
