using AutoMapper;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WithCodesBlog.Web.UI.ViewModels;

namespace WithCodesBlog.Web.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactManager _contactManager;
        private readonly ContactValidator _validator;
        private ValidationResult _validationResult;
        private readonly IMapper _mapper;

        public ContactController(ContactManager contactManager, ContactValidator validator, IMapper mapper)
        {
            _contactManager = contactManager;
            _validator = validator;
            _mapper = mapper;
        }


        [Route("Iletisim/")]
        [HttpGet]
        public IActionResult Index()
        {
            var contact = _contactManager.GetAllList()!.FirstOrDefault();
            if (contact != null)
            {
                 return View(contact);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("Iletisim/")]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("FullName,Email,Subject,Message")] ContactViewModel viewModel)
        {
            
            var contact = _mapper.Map<Contact>(viewModel);

            _validationResult = _validator.Validate(contact);
            if (_validationResult.IsValid)
            {
                contact.Status = true;
                contact.SendingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                contact.BlogEmail = null;
                contact.BlogAddress = null;
                contact.PhoneNumber = null;
                TempData["Alert"] = "Mesajınız başarılı bir şekilde gönderildi.";
                _contactManager.Add(contact);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in _validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View();
        }
    }
}
