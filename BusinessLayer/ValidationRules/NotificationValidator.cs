using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class NotificationValidator : AbstractValidator<Notification>
    {
        public NotificationValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen bildirim başlığını yazınız.").MinimumLength(5).WithMessage("Bildirim başlığı en az 5 karekter olması gerekmektedir.").MaximumLength(15).WithMessage("Bildirim başlığı en fazla 15 karekter olabilir.");
            RuleFor(x => x.ContentText).NotEmpty().WithMessage("Lütfen bildirim içeriğini yazınız.").MinimumLength(5).WithMessage("Bildirim içeriği en az 5 karekter olması gerekmektedir.").MaximumLength(30).WithMessage("Bildirim başlığı en fazla 30 karekter olabilir.");
        }
    }
}
