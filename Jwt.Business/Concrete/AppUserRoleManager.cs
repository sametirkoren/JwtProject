using Jwt.Business.Interfaces;
using JwtProject.DataAccess.Interfaces;
using JwtProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Business.Concrete
{
    public class AppUserRoleManager :  GenericManager<AppUserRole> , IAppUserRoleService
    {
        public AppUserRoleManager(IGenericDal<AppUserRole> genericDal) : base(genericDal)
        {

        }
    }
}
