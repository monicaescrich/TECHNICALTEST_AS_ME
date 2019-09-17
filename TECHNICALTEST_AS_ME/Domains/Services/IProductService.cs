﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Models;
using TECHNICALTEST_AS_ME.Domains.Services.Responses;

namespace TECHNICALTEST_AS_ME.Domains.Services
{
    public interface IProductService
    {
        Task<CreateProductResponse> CreateProductAsync(Product product);
        Task<IEnumerable<Product>> ListAsync(int limit, int offset);
    }
}

