using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WithCodesBlog.Web.UI.ViewComponents.HashtagViewComponent
{
    public class HashtagList:ViewComponent
    {
        private readonly IHashtagDal _hashtagDal;

        public HashtagList(IHashtagDal hashtagDal)
        {
            _hashtagDal = hashtagDal;
            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await Task.Run(() => _hashtagDal.GetAll());
            return View(result);
        }

    }
}
