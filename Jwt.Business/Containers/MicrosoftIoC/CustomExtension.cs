﻿using FluentValidation;
using Jwt.Business.Concrete;
using Jwt.Business.Interfaces;
using Jwt.Business.ValidationRules.FluentValidation;
using JwtProject.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using JwtProject.DataAccess.Interfaces;
using JwtProject.Entities.Dtos.AppUserDtos;
using JwtProject.Entities.Dtos.ProductDtos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Business.Containers.MicrosoftIoC
{
    public static class CustomExtension
    {
        
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserRoleDal, EfAppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();

            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();

            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();

            services.AddScoped<IJwtService, JwtManager>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();

            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddDtoValidator>();
        }
    }
}
