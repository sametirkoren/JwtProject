using JwtProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Business.Interfaces
{
    public interface IJwtService
    {
        string GenereateJwtToken(AppUser appUser, List<AppRole> roles);
    }
}
