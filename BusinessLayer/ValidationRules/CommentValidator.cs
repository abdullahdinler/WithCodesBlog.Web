using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CommentValidator:AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen ad soyad alanını doldurunuz").MinimumLength(5)
                .WithMessage("Ad soyad alanı 5 karekterden büyük olması gerekmektedir.");
            RuleFor(x => x.CommentText).NotEmpty().WithMessage("Lütfen bir yorum yazınız").MinimumLength(8).WithMessage("Yorumunuz en az 8 karekter olması gerekmektedir.").MaximumLength(50).WithMessage("Yorum 50 karakterden fazla olamaz.");
            RuleFor(x => x.UserEmail).NotEmpty().WithMessage("Lütfen bir e-posta adresi giriniz.").EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz.");
        }
    }
}
