using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Models;

namespace TECHNICALTEST_AS_ME.Domains.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync(int limit, int offset);
        void AddAsync(Product product);
        Task<Product> FindByIdAsync(int productId);
    }
}
