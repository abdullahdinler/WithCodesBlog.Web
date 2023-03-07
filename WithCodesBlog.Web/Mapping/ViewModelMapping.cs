using AutoMapper;
using EntityLayer.Concrete;
using WithCodesBlog.Web.UI.ViewModels;

namespace WithCodesBlog.Web.UI.Mapping
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Contact, ContactViewModel>().ReverseMap();
        }
    }
}
