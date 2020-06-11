using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jwt.Business.Interfaces;
using JwtProject.Entities.Dtos.AppUserDtos;
using JwtProject.WebApi.CustomFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService, IAppUserService appUserService)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
        }

        [HttpGet("[action]")]
        [ValidModel]
        public async Task<IActionResult> Signin(AppUserLoginDto appUserLoginDto)
        {
            // userName =>  var mı ? 
            // password => eşleniyor mu ? 

            var appUser = await _appUserService.FindByUserName(appUserLoginDto.UserName);
            if(appUser == null)
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı.");
            }
            else
            {
                if(await _appUserService.CheckPassword(appUserLoginDto))
                {
                    var token = _jwtService.GenereateJwtToken(appUser, null);
                    return Created("", token);
                }

                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
           
        }
    }
}