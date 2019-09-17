using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Models;
using TECHNICALTEST_AS_ME.Domains.Repositories;
using TECHNICALTEST_AS_ME.Domains.Services;
using TECHNICALTEST_AS_ME.Domains.Services.Responses;

namespace TECHNICALTEST_AS_ME.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> ListAsync(int limit, int offset)
        {
            return await _productRepository.ListAsync(limit,offset);
        }

   
        public async Task<CreateProductResponse> CreateProductAsync(Product product)
        {
            var existingProduct = await _productRepository.FindByIdAsync(product.ProductID);
            if (existingProduct != null)
            {
                return new CreateProductResponse(false, "Product ID already in use.", null);
            }

            

             _productRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return new CreateProductResponse(true, null, product);
        }

        public async Task<Product> FindByIdAsync(int productID)
        {
            return await _productRepository.FindByIdAsync(productID);
        }
    }
}
