using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class SocialMediaValidator:AbstractValidator<SocialMedia>
    {
        public SocialMediaValidator()
        {
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Lütfen bir icon giriniz");
            RuleFor(x => x.SocialMediaUri).NotEmpty().WithMessage("Lütfen sosyal medya adresinizi giriniz");
        }
    }
}
