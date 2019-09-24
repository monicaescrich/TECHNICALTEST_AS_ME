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

        public async Task<IEnumerable<Product>> ListAllAsync()
        {                                   
            return await _context.Products.Where(P => P.Discontinued == false).Include(p=>p.Category).ToListAsync();
        }

        public void Update(Product product)
        {
             _context.Products.Update(product);
        }

        public async Task<IEnumerable<Product>> ListAsync(int limit, int offset)
        {
            return await _context.Products.Skip(offset).Take(limit).OrderByDescending(p=>p.Likes).Include(p=>p.Category).ToListAsync();
        }
        public async Task<IEnumerable<Product>> ListOrderByNameAsync(int limit, int offset)
        {
            return await _context.Products.Skip(offset).Take(limit).OrderByDescending(p=>p.ProductName).Include(p=>p.Category).ToListAsync();
        }
        public async Task<IEnumerable<Product>> ListByNameAsync(int limit, int offset,string name)
        {
            return await _context.Products.Where(p=>p.ProductName.Contains(name)).Skip(offset).Take(limit).OrderByDescending(p=>p.Likes).ToListAsync();
        }

        


       public async Task<IEnumerable<Product>> ListByNameOrderByPriceAsync(int limit, int offset, string name)
        {
            return await _context.Products.Where(p => p.ProductName.Contains(name)).Skip(offset).Take(limit).OrderByDescending(p => p.UnitPrice).ToListAsync();
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
