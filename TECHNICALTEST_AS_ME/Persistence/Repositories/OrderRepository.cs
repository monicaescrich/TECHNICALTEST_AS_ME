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
    public class OrderRepository : BaseRepository, IOrderRepository
    {

        public OrderRepository(AppDbContext context) : base(context)
        {
        }
        public void AddOrdersAsync(Order order)
        {
            _context.Orders.Add(order);
        }
        public async Task<Order> FindByOrderIdAsync(int orderID)
        {
            return await _context.Orders.SingleOrDefaultAsync(u => u.OrdersID == orderID);
        }

        public void AddDetailToOrder(IEnumerable<OrderDetail> order)
        {
            foreach(var or in order)
                _context.OrderDetails.Add(or);
            
        }
    }
}
