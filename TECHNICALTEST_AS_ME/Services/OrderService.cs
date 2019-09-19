using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Models;
using TECHNICALTEST_AS_ME.Domains.Repositories;
using TECHNICALTEST_AS_ME.Domains.Services;
using TECHNICALTEST_AS_ME.Domains.Services.Responses;

namespace TECHNICALTEST_AS_ME.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateOrderResponse> AddOrdersAsync(Order order)
        {
            var existingOrder = await _orderRepository.FindByOrderIdAsync(order.OrdersID);
            if (existingOrder != null)
            {
                return new CreateOrderResponse(false, "Order ID already in use.", order);
            }

             _orderRepository.AddOrdersAsync(order);
            await _unitOfWork.CompleteAsync();

            return new CreateOrderResponse(true, null, order);
        }

        public async Task<CreateOrderResponse> AddDetailToOrder(IEnumerable<OrderDetail> orderDetail)
        {
             _orderRepository.AddDetailToOrder(orderDetail);
            await _unitOfWork.CompleteAsync();
            return new CreateOrderResponse(true, null, orderDetail.First());
        }

        public async Task<Order> FindByOrderIdAsync(int orderID)
        {
            return await _orderRepository.FindByOrderIdAsync(orderID);
        }
    }
}
