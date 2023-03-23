using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommentAnswerValidator : AbstractValidator<CommentAnswer>
    {
        public CommentAnswerValidator()
        {
            RuleFor(x => x.Answer).NotEmpty().WithMessage("Cevap alanı boş bırakılamaz");
        }
    }
}
