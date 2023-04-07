using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.ViewComponents.AdminDashboard
{
    public class DashboardCategoryList : ViewComponent
    {
        private readonly CategoryManager _categoryManager;

        public DashboardCategoryList(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryManager.CategoriesWithBlogs();
            return View(categories);
        }
    }
}
