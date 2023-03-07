using System.ComponentModel.DataAnnotations;

namespace WithCodesBlog.Web.UI.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Ad Soyad alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Ad alanı en fazla 50 karakter olabilir.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Başlık alanı en fazla 100 karakter olabilir.")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mesaj alanı zorunludur.")]
        [MaxLength(1000, ErrorMessage = "Mesaj alanı en fazla 1000 karakter olabilir.")]
        public string? Message { get; set; }
    }
}
