using JwtProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.Entities.Token
{
    public class JwtAccessToken : IToken
    {
        public string Token { get; set; }
    }
}
