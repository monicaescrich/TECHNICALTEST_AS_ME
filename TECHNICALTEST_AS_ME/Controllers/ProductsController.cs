using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TECHNICALTEST_AS_ME.Domains.Models;
using TECHNICALTEST_AS_ME.Domains.Services;
using TECHNICALTEST_AS_ME.Resources;

namespace TECHNICALTEST_AS_ME.Controllers
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


        [HttpGet]
        [Route("/api/[controller]/{limit}/{offset}")]
        public async Task<IEnumerable<ProductResource>> GetAllAsync(int limit, int offset)
        {
            var products = await _productService.ListAsync(limit,offset);
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return resources;
        }

        [HttpPost]
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

            var userResource = _mapper.Map<Product, ProductResource>(response.Product);
            return Ok(userResource);
        }
    }
}