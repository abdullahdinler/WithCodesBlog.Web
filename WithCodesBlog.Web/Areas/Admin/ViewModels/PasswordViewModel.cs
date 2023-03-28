using System.ComponentModel.DataAnnotations;

namespace WithCodesBlog.Web.UI.Areas.Admin.ViewModels
{
    public class PasswordViewModel
    {
        [Required(ErrorMessage = "Mevcut şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mevcut Şifre")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Yeni şifrenizi giriniz.")]
        [StringLength(100, ErrorMessage = "{0}, en az {2} ve en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre Tekrar")]
        [Compare("NewPassword", ErrorMessage = "Yeni şifreniz eşleşmiyor.")]
        public string ConfirmNewPassword { get; set; }
    }
}
