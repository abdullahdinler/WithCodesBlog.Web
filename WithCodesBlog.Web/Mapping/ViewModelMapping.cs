using AutoMapper;
using EntityLayer.Concrete;
using WithCodesBlog.Web.UI.Areas.Admin.ViewModels;
using WithCodesBlog.Web.UI.ViewModels;

namespace WithCodesBlog.Web.UI.Mapping
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Contact, ContactViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<AppUser, LogInViewModel>().ReverseMap();
            CreateMap<AppUser, AppUserViewModel>().ReverseMap();
        }
    }
}
