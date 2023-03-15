using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AppUserValidator:AbstractValidator<AppUser>
    {
        public AppUserValidator()
        {
            RuleFor(x=>x.NameSurname).NotEmpty().WithMessage("Lütfen bu alanı boş bırakmayınız.").MinimumLength(5).WithMessage("Lütfen en az 5 karakter uzunluğunda bir metin giriniz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen bu alanı boş bırakmayınız.").MinimumLength(5).WithMessage("Lütfen en az 5 karakter uzunluğunda bir metin giriniz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen bir e-posta adresi giriniz.").EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz.");
            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("Şifre alanı boş bırakılamaz.")
                .MinimumLength(8).WithMessage("Şifreniz en az 8 karakter uzunluğunda olmalıdır.")
                .Must(password => password.Any(char.IsDigit)).WithMessage("Şifreniz en az bir rakam içermelidir.")
                .Must(password => password.Any(char.IsLetter)).WithMessage("Şifreniz en az bir harf içermelidir.");
            RuleFor(x => x.ImageUri)
                .Must(fileName =>
                    string.IsNullOrEmpty(fileName) ||
                    new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" }
                        .Contains(Path.GetExtension(fileName).ToLowerInvariant()))
                .WithMessage("Lütfen geçerli bir resim dosyası seçin.");
        }
    }
}
