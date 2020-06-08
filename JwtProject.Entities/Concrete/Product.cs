using JwtProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.Entities.Concrete
{
    public class Product : ITable
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
