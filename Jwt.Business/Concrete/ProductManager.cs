using Jwt.Business.Interfaces;
using JwtProject.DataAccess.Interfaces;
using JwtProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Business.Concrete
{
    public class ProductManager : GenericManager<Product> , IProductService
    {
        public ProductManager(IGenericDal<Product> genericDal) : base(genericDal)
        {

        }
    }
}
