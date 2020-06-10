using JwtProject.DataAccess.Interfaces;
using JwtProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRoleRepository : EfGenericRepository<AppUserRole> , IAppUserRoleDal
    {
    }
}
