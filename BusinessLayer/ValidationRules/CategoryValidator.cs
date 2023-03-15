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
           
        }
    }
}
