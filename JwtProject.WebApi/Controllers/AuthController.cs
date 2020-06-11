using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jwt.Business.Interfaces;
using JwtProject.Entities.Concrete;
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
        private readonly IMapper _mapper;
        public AuthController(IJwtService jwtService, IAppUserService appUserService, IMapper mapper)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
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
                    var roles = await _appUserService.GetRolesByUserName(appUserLoginDto.UserName);
                    var token = _jwtService.GenereateJwtToken(appUser, roles);
                    return Created("", token);
                }

                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
           
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto)
        {
            var appUser = await _appUserService.FindByUserName(appUserAddDto.FullName);
            if (appUser != null)
            {
                return BadRequest($"{appUserAddDto.UserName} zaten alınmış.");
            }
            await _appUserService.Add(_mapper.Map<AppUser>(appUserAddDto));
            return Created("", appUserAddDto);
        }
    }
}