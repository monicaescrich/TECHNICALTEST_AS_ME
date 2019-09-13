using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Models;

namespace TECHNICALTEST_AS_ME.Domains.Services
{
   public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}
