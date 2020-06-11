using Jwt.Business.Interfaces;
using Jwt.Business.StringInfos;
using JwtProject.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jwt.Business.Concrete
{
    public class JwtManager : IJwtService
    {
        public string GenereateJwtToken(AppUser appUser , List<AppRole> roles)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer : JwtInfo.Issuer , audience:JwtInfo.Audience , notBefore:DateTime.Now , expires:DateTime.Now.AddMinutes(JwtInfo.TokenExpiration),signingCredentials: signingCredentials , claims:GetClaims(appUser , roles));

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwtSecurityToken);
        }

        private List<Claim> GetClaims(AppUser appUser, List<AppRole> roles)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));

            //if(roles.Count > 0)
            //{
            //    foreach (var role in roles)
            //    {
            //        claims.Add(new Claim(ClaimTypes.Role, role.Name));
            //    }
            //}

            return claims;
        }
    }
}
