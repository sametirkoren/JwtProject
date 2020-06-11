using FluentValidation;
using JwtProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Business.ValidationRules.FluentValidation
{
    public class ProductUpdateDtoValidator : AbstractValidator<Product>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(0, int.MaxValue);
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ad alanı boş bırakılamaz");
        }
    }
}
