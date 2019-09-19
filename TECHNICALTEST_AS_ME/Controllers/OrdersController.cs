using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TECHNICALTEST_AS_ME.Domains.Models;
using TECHNICALTEST_AS_ME.Domains.Services;
using TECHNICALTEST_AS_ME.Resources;

namespace TECHNICALTEST_AS_ME.Controllers
{
   
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        [Route("api/[controller]")]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderResource orderHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = _mapper.Map<OrderResource, Order>(orderHeader);

            var response = await _orderService.AddOrdersAsync(order);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var userResource = _mapper.Map<Order, OrderResource>(response.Order);
            return Ok(userResource);
        }

        [HttpPost]
        [Authorize]
        [Route("api/DetailOrder")]
        public async Task<IActionResult> CreateDetailToOrder([FromBody] IEnumerable<OrderDetail> orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var order = _mapper.Map<OrderDetailResource[], OrderDetail[]>(orderDetail);

            var response = await _orderService.AddDetailToOrder(orderDetail);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var userResource = _mapper.Map<Order, OrderResource>(response.Order);
            return Ok(userResource);
        }
    }
}