using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x=>x.FullName).NotEmpty().WithMessage("Lütfen ad soyad alanını doldurunuz").MinimumLength(5)
                .WithMessage("Ad soyad alanı 5 karekterden büyük olması gerekmektedir.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen bir e-posta adresi giriniz.").EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Lütfen bir konu giriniz").MinimumLength(5).WithMessage("Konu başlığı en az 5 karekter olması gerekmektedir.").MaximumLength(30).WithMessage("Konu başlığı en fazla 30 karekter olabilir.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Lütfen mesaj alanını doldurunuz").MinimumLength(8)
                .WithMessage("Mesajınız en az 8 karekter olması gerekmektedir.");
        }
    }
}
