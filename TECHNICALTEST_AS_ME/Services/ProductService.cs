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

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> ListAsync(int limit, int offset)
        {
            return await _productRepository.ListAsync(limit,offset);
        }
        public async Task<IEnumerable<Product>> ListAllAsync()
        {
            return await _productRepository.ListAllAsync();
        }
        public async Task<IEnumerable<Product>> ListOrderByNameAsync(int limit, int offset)
        {
            return await _productRepository.ListOrderByNameAsync(limit, offset);
        }

        public async Task<IEnumerable<Product>> ListByNameAsync(int limit, int offset,string name)
        {
            return await _productRepository.ListByNameAsync(limit, offset,name);
        }
        public async Task<IEnumerable<Product>> ListByNameOrderByPriceAsync(int limit, int offset, string name)
        {
            return await _productRepository.ListByNameOrderByPriceAsync(limit, offset, name);
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


        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public async Task<CreateProductResponse> UpdateAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);

            if (existingProduct == null)
                return new CreateProductResponse(false, "Product ID already in use.", null);

            if (product.ProductName != null)
                existingProduct.ProductName = product.ProductName;
            if (product.UnitPrice != existingProduct.UnitPrice && product.UnitPrice>0)
                existingProduct.UnitPrice = product.UnitPrice;
            if (product.UnitsInStock != existingProduct.UnitsInStock && product.UnitsInStock > 0)
                existingProduct.UnitsInStock = product.UnitsInStock;
                

            existingProduct.Discontinued = product.Discontinued;

            try
            {
                _productRepository.Update(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new CreateProductResponse(true, "Modified" ,existingProduct);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CreateProductResponse(true,$"An error occurred when updating the product: {ex.Message}",null);
            }
        }

        public async Task<Product> FindByIdAsync(int productID)
        {
            return await _productRepository.FindByIdAsync(productID);
        }
    }
}
