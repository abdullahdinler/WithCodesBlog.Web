using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace WithCodesBlog.Web.UI.ViewComponents.MessageViewComponent
{
    public class NavBarMessageList:ViewComponent
    {
        private readonly ContactManager _contactManager;


        public NavBarMessageList(ContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var messages = await _contactManager.GetAllList()!.OrderByDescending(x=>x.SendingDate).ToListAsync();
            return messages != null ? View(messages) : View(null);
        }
    }
}
