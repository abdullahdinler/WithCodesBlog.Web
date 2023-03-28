using AutoMapper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WithCodesBlog.Web.UI.Areas.Admin.ViewModels;

namespace WithCodesBlog.Web.UI.ViewComponents.AuthorViewComponent
{
    public class AuthorUpdate : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AuthorUpdate(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity is null) return Content("Kullanıcı Bulunamadıç");

            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            var author = _mapper.Map<ProfileViewModel>(appUser);
            return View(author);
        }
    }
}
