using System.ComponentModel.DataAnnotations;

namespace WithCodesBlog.Web.UI.Areas.Admin.ViewModels
{
    public class LogInViewModel
    {
       
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        public string Password { get; set; }
    }
}
