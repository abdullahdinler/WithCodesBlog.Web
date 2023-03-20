using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.ContentText).NotEmpty().WithMessage("Lütfen bu alanı boş bırakmayınız.").MinimumLength(100)
                .WithMessage("Lütfen en az 100 karakter uzunluğunda bir metin giriniz.");
            RuleFor(x => x.ImageUri)
                .NotEmpty().WithMessage("Resim alanı boş bırakılamaz.")
                .Must(image => image.EndsWith(".jpg") || image.EndsWith(".jpeg") || image.EndsWith(".png"))
                .WithMessage("Resim alanına sadece JPG, JPEG veya PNG formatında dosya yükleyebilirsiniz.");

        }
    }
}
