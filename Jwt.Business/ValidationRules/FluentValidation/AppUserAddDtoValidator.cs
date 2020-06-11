using FluentValidation;
using JwtProject.Entities.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Business.ValidationRules.FluentValidation
{
    public class AppUserAddDtoValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            RuleFor(I => I.FullName).NotEmpty().WithMessage("Ad soyad alanı boş geçilemez.");
        }
    }
}
