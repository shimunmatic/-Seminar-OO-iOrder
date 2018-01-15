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
    [Authorize]
    public class OrderController : Controller
    {
        private IOrderService OrderService;

        public OrderController(IOrderService orderService)
        {
            OrderService = orderService;
        }

        // GET: api/Order/CustomerHistory/5
        [HttpGet("CustomerHistory/{id}", Name = "GetOrders")]
        [Authorize(Roles = "CUSTOMER")]
        public IEnumerable<Order> Get(long id)
        {
            return OrderService.GetCustomerHistoryForEstablishmentId(User.Identity.Name, id);
        }

        // GET: api/Order/EstablishmentHistory/5
        [HttpGet("EstablishmentHistory/{id}", Name = "GetOrdersForEst")]
        [Authorize(Roles = "EMPLOYEE, ADMIN")]
        public IEnumerable<Order> GetEstablishmentHistory(long id)
        {
            return OrderService.GetHistoryEstablishmentId(id);
        }

        // POST: api/Order
        [HttpPost]
        [Authorize(Roles = "CUSTOMER")]
        public void Post([FromBody]Order order)
        {
            order.CustomerId = User.Identity.Name;
            order.Date = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time"));
            OrderService.Save(order);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "CUSTOMER, ADMIN, EMPLOYEE")]
        public void Delete(long id)
        {
            OrderService.Delete(id);

        }
    }
}
