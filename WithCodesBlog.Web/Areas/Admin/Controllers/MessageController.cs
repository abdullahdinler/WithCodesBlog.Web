using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;


namespace WithCodesBlog.Web.UI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly ContactManager _contactManager;

        public MessageController(ContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        public async Task<IActionResult> Index(string search, int? page)
        {
            ViewBag.Alert = TempData["Durum"] as string;
            int _page = page ?? 1;
            string _search = search ?? "";

            if (_search != null)
            {
                var contacts = await _contactManager.SearchContacts(_search).OrderByDescending(x => x.Id).ToPagedListAsync(_page, 5);
                return View(contacts);
            }
            var values = await _contactManager.GetAllList().OrderByDescending(x=>x.Id).ToPagedListAsync(_page, 5);

            return View(values);
            
        }

        public IActionResult ReadMessage(int id)
        {
            if (id > 0)
            {
                var message = _contactManager.Get(id);
                if (message != null)
                {
                    message.Status = false;
                    _contactManager.Update(message);
                    return View(message);
                }
                
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int[] selectedIds)
        {
            if (selectedIds.Length > 0)
            {
                foreach (var i in selectedIds)
                {
                    var messages = _contactManager.Get(i);
                    if (messages != null)
                    {
                        TempData["Durum"] = "Mesaj başarılı bir şekilde silindi.";
                        _contactManager.Delete(messages);
                    }
                }
                return RedirectToAction("Index" ,"Message");
            }

            return NotFound();
        }
    }
}
