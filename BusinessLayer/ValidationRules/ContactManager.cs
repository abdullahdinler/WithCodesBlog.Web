using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactManager:AbstractValidator<Contact>
    {
        public ContactManager()
        {
            RuleFor(x=>x.FullName).NotEmpty().WithMessage("Lütfen ad soyad alanını doldurunuz").MinimumLength(5)
                .WithMessage("Ad soyad alanı 5 karekterden büyük olması gerekmektedir.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen bir e-posta adresi giriniz.").EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Lütfen konu boş geçilemez.").MinimumLength(5).WithMessage("Konu başlığı en az 5 karekter olması gerekmektedir.").MaximumLength(30).WithMessage("Konu başlığı en fazla 30 karekter olabilir.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Lütfen mesaj alanını doldurunuz").MinimumLength(8).WithMessage("Mesajınız en az 8 karekter olması gerekmektedir.").MaximumLength(50).WithMessage("Mesajınız 50 karakterden fazla olamaz.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Lütfen telefon alanını doldurunuz").MinimumLength(10)
                .WithMessage("Telefon alanı 10 karekterden büyük olması gerekmektedir.");
            RuleFor(x => x.BlogEmail).NotEmpty().WithMessage("Lütfen bir e-posta adresi giriniz.").EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz.");
            RuleFor(x => x.BlogAddress).NotEmpty().WithMessage("Lütfen bir adres giriniz.");
        }
    }
}
