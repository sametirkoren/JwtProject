using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jwt.Business.Interfaces;
using JwtProject.Entities.Concrete;
using JwtProject.Entities.Dtos.ProductDtos;
using JwtProject.WebApi.CustomFilters;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
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
           
            await _productService.Add(_mapper.Map<Product>(productAddDto));
            return Created("", productAddDto);
           
        }

        [HttpPut]
        [ValidModel]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _productService.Update(_mapper.Map<Product>(productUpdateDto));
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

        [Route("/error")]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            
            // loglama

            return Problem(detail: "api da bir hata olustu, en kisa zamanda düzeltilecek");
        }
    }
}