using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Models;

namespace TECHNICALTEST_AS_ME.Domains.Services.Responses
{
    public class CreateProductResponse: BaseResponse
    {
        public Product Product { get; private set; }

        public CreateProductResponse(bool success, string message, Product product) : base(success, message)
        {
            Product = product;
        }
    }
}
