using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.ViewComponents.CategoryViewComponent
{
    public class MenuCategoryList : ViewComponent
    {
        private readonly ICategoryDal _category;

        public MenuCategoryList(ICategoryDal category)
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
