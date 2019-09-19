using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Models;
using TECHNICALTEST_AS_ME.Domains.Services.Responses;

namespace TECHNICALTEST_AS_ME.Domains.Services
{
    public interface IOrderService
    {
        Task<CreateOrderResponse> AddOrdersAsync(Order order);
        Task<CreateOrderResponse> AddDetailToOrder(IEnumerable<OrderDetail> orderDetail);
        Task<Order> FindByOrderIdAsync(int orderID);
    }
}
