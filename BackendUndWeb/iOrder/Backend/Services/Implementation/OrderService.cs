using Backend.Models.Business;
using Backend.Repositories.Interface;
using Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private IOrderRepository OrderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            OrderRepository = orderRepository;
        }

        public IEnumerable<Order> GetCustomerHistoryForEstablishmentId(string username, long id)
        {
            var allOrders = OrderRepository.GetOrdersForCustomer(username);
            return allOrders.Where(o => o.EstablishmentId == id).ToList();
        }

        public IEnumerable<Order> GetHistoryEstablishmentId(long id)
        {
            return OrderRepository.GetOrdersForEstablishment(id);
        }

        public void Save(Order order)
        {
            OrderRepository.Save(order);
        }
    }
}
