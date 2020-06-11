using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jwt.Business.Interfaces;
using JwtProject.Entities.Concrete;
using JwtProject.Entities.Dtos.ProductDtos;
using JwtProject.WebApi.CustomFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products =await  _productService.GetAll();
            return Ok(products);
        }

        //api/products/3

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> GetById (int id)
        {
            var product = await _productService.GetById(id);

            return Ok(product);
        }
        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
           
            await _productService.Add(new Product { Name = productAddDto.Name });
            return Created("", productAddDto);
           
        }

        [HttpPut]
        [ValidModel]
        public async Task<IActionResult> Update(Product product)
        {
            await _productService.Update(product);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Remove(new Product() { Id = id });
            return NoContent();
        }


        [HttpGet("test/{id}")]
        [ServiceFilter(typeof(ValidId<AppUser>))]

        public IActionResult Test(int id)
        {
            return Ok();
        }
    }
}