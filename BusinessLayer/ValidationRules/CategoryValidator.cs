using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Lütfen kategori isim alanını doldurunuz.").MaximumLength(50).WithMessage("Lütfen kategori ismi 50 karekteri aşamaz.");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Lütfen kategori açıklama alanını doldurunuz.").MinimumLength(15).WithMessage("Lütfen kategori acıklama alanına 15 karekterden büyük bir içerik giriniz.");
        }
    }
}
