using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Models;

namespace TECHNICALTEST_AS_ME.Domains.Services.Responses
{
    public class CreateOrderResponse: BaseResponse
    {
        public Order Order { get; private set; }
        public OrderDetail OrderDetail { get; private set; }

        public CreateOrderResponse(bool success, string message, Order order) : base(success, message)
        {
            Order = order;
        }
        public CreateOrderResponse(bool success, string message, OrderDetail order) : base(success, message)
        {
            OrderDetail = order;
        }
    }
}
