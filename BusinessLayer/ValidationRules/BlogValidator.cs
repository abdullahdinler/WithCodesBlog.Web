using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x=>x.CategoryId).NotEmpty().WithMessage("Lütfen kategori alanını doldurunuz.");
            RuleFor(x=>x.AppUser).NotEmpty().WithMessage("Lütfen yazar alanını doldurunuz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen blog başlığını yazınız.").MinimumLength(5).WithMessage("Blog başlığı en az 5 karekter olması gerekmektedir.").MaximumLength(30).WithMessage("Blog başlığı en fazla 30 karekter olabilir.");
            RuleFor(x => x.ContentText).NotEmpty().WithMessage("Blog içeriği boş olamaz").MinimumLength(5).WithMessage("Blog içeriği en az 100 karekter olması gerekmektedir.");
            RuleFor(x => x.ImageUri)
                .NotEmpty().WithMessage("Resim alanı boş bırakılamaz.")
                .Must(image => image.EndsWith(".jpg") || image.EndsWith(".jpeg") || image.EndsWith(".png"))
                .WithMessage("Resim alanına sadece JPG, JPEG veya PNG formatında dosya yükleyebilirsiniz.");
            RuleFor(x => x.ThumbnailImageUri)
                .NotEmpty().WithMessage("Resim alanı boş bırakılamaz.")
                .Must(image => image.EndsWith(".jpg") || image.EndsWith(".jpeg") || image.EndsWith(".png"))
                .WithMessage("Resim alanına sadece JPG, JPEG veya PNG formatında dosya yükleyebilirsiniz.");


        }
    }
}
