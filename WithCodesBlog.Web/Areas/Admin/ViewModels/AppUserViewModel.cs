using System.ComponentModel.DataAnnotations;

namespace WithCodesBlog.Web.UI.Areas.Admin.ViewModels
{
    public class AppUserViewModel
    {
        [Required(ErrorMessage = "Lütfen bir kullanıcı adı giriniz.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Lütfen yazarın adını soyadını giriniz.")]
        public string? NameSurname { get; set; }

        [Required(ErrorMessage = "Lütfen bir email adresi giriniz.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Lütfen bir şifre giriniz.")]
        public string? PasswordHash { get; set; }

        [Required(ErrorMessage = "Lütfen yazarı için bir gorsel seciniz.")]
        public string? ImageUri { get; set; }

        [Required(ErrorMessage = "Lütfen bir rol belirleyin")]
        public string? IsAdmin { get; set; }
    }
}
