using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Models;

namespace TECHNICALTEST_AS_ME.Domains.Repositories
{
   public  interface IOrderRepository
    {
        void AddOrdersAsync(Order order);
        void AddDetailToOrder(IEnumerable<OrderDetail>orderDetail);
        Task<Order> FindByOrderIdAsync(int orderID);
    }
}
