using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TECHNICALTEST_AS_ME.Domains.Models;
using TECHNICALTEST_AS_ME.Domains.Services;
using TECHNICALTEST_AS_ME.Resources;

namespace TECHNICALTEST_AS_ME.Controllers
{
    
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


        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IEnumerable<ProductResource>> GetAllAsync(int limit, int offset, string orderBy = "")
        {
            IEnumerable<Product> products;
            if (orderBy.ToUpper().Equals("LIKES"))
            {
                products = await _productService.ListAsync(limit, offset);
            }
            else
            {
                products = await _productService.ListOrderByNameAsync(limit, offset);
            }
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return resources;
        }

        [HttpGet]
        [Route("api/GetProductByName")]
        public async Task<IEnumerable<ProductResource>> GetProductByNameAsync(int limit, int offset, string name,string orderBy="" )
        {
            IEnumerable<Product> products;
            if (orderBy.ToUpper().Equals("LIKES"))
            {
                 products = await _productService.ListByNameAsync(limit, offset, name);
            }
            else
            {
                 products = await _productService.ListByNameOrderByPriceAsync(limit, offset, name);
            }
                
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return resources;
        }

        [HttpGet]
        [Route("api/ListAllProducts")]
        public async Task<IEnumerable<ProductResource>> ListAllAsync()
        {
            
            var   products = await _productService.ListAllAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return resources;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [Route("api/[controller]")]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductResource productInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _mapper.Map<ProductResource, Product>(productInfo);

            var response = await _productService.CreateProductAsync(product);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var productResource = _mapper.Map<Product, ProductResource>(response.Product);
            return Ok(productResource);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ProductResource productUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _mapper.Map<ProductResource, Product>(productUpdate);
            var result = await _productService.UpdateAsync(id, product);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResource);
        }
    }
}