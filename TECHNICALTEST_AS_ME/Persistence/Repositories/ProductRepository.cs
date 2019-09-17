using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Models;
using TECHNICALTEST_AS_ME.Domains.Repositories;
using TECHNICALTEST_AS_ME.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace TECHNICALTEST_AS_ME.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> ListAsync(int limit, int offset)
        {
            return await _context.Products.Skip(offset).Take(limit).ToListAsync();
        }

        public void AddAsync(Product product)
        {
            _context.Products.Add(product);
        }

        public async Task<Product> FindByIdAsync(int productID)
        {
            return await _context.Products.SingleOrDefaultAsync(u => u.ProductID == productID);
        }
    }
}
