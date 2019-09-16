using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECHNICALTEST_AS_ME.Domains.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
