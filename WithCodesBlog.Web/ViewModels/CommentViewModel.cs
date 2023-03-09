using System.ComponentModel.DataAnnotations;

namespace WithCodesBlog.Web.UI.ViewModels
{
    public class CommentViewModel
    {
        public int BlogId { get; set; }

        [Required(ErrorMessage = "Ad Soyad alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Ad alanı en fazla 50 karakter olabilir.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        public string? UserEmail { get; set; }

        [Required(ErrorMessage = "Yorum alanı zorunludur.")]
        [MaxLength(500, ErrorMessage = "Yorum alanı en fazla 500 karakter olabilir.")]
        public string? CommentText { get; set; }

        public string? ReturnUrl { get; set; }
        
    }
}
