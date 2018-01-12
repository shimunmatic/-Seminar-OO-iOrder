using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Business;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        private IOrderService OrderService;

        public OrderController(IOrderService orderService)
        {
            OrderService = orderService;
        }

        // GET: api/Order/5
        [HttpGet("Establishment/{id}", Name = "GetOrders")]
        public IEnumerable<Order> Get(int id)
        {
            return OrderService.GetCustomerHistoryForEstablishmentId(User.Identity.Name, id);
        }

        // POST: api/Order
        [HttpPost]
        [Authorize(Roles = "CUSTOMER")]
        public void Post([FromBody]Order order)
        {
            order.CustomerId = User.Identity.Name;
            order.Date = DateTime.Now;
            OrderService.Save(order);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
