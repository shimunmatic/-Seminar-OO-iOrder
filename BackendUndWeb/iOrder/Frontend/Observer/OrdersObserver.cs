using Backend.Models.Business;
using Backend.Notifications.Observable;
using Backend.Notifications.Observer;
using Backend.Services.Interface;
using Frontend.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Observer
{
    public class OrdersObserver : ObserverAbstract
    {
        private OrdersHub hub;
        private IMemoryCache cache;
        private IOrderService orderService;

        public OrdersObserver(IObservable observable, OrdersHub hub, IMemoryCache cache, IOrderService orderService) : base(observable)
        {
            // Inject SignalR orders hub.
            this.hub = hub;
            this.cache = cache;
            this.orderService = orderService;
        }

        public override void Notify(long establishmentId)
        {
            // Fetch orders
            OrdersToOrderModel(establishmentId);
            //Send refresh notification
            hub.Send("ADDED", "DUMMY");
        }
        
        private void OrdersToOrderModel(long establishmentId)
        {
            var establishment = cache.Get<Establishment>("establishment");
            var user = cache.Get<User>("user");
            List<OrderModel> orders = orderService.GetUnpaidOrdersForEstablishmentId(establishmentId)
            .OrderByDescending(o => o.Date)
            .Select(order => new OrderModel
            {
                Id = order.Id,
                Date = order.Date,
                Paid = order.Paid,
                Price = order.Price,
                OrderedProducts = order.OrderedProducts,
                Customer = order.CustomerId,
                Employee = user.Username,
                Location = establishment.Locations.First(l => l.Id == order.LocationId),
                Establishment = establishment
            })
            .ToList();

            // Cache orders and establishment
            cache.Set("orders", orders);
        }
    }
}
