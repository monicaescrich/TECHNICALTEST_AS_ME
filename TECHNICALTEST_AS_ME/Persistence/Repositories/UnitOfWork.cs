using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Repositories;
using TECHNICALTEST_AS_ME.Persistence.Contexts;

namespace TECHNICALTEST_AS_ME.Persistence.Repositories
{
   
        public class UnitOfWork : IUnitOfWork
        {
            private readonly AppDbContext _context;

            public UnitOfWork(AppDbContext context)
            {
                _context = context;
            }

            public async Task CompleteAsync()
            {
                await _context.SaveChangesAsync();
            }
        }
    
}
