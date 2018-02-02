using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using Backend.Models.ModelView;
using Backend.Notifications.Observable;
using Backend.Services.Interface;
using Backend.Models.Business;
using Backend.Notifications.Observer;
using Microsoft.Extensions.Caching.Memory;
using Frontend.Observer;

namespace Frontend.Controllers
{
    public class OrdersController : Controller
    {

        private IOrderService orderService;
        private ILocationService locationService;
        private IEstablishmentService establishmentService;
        private IUserService userService;
        private IMemoryCache cache;
        private ObserverAbstract observer;
        private OrdersHub hub;

        public OrdersController(OrdersHub hub, IMemoryCache cache, IObservable notificationsObservable, IOrderService orderService, IUserService userService, ILocationService locationService,IEstablishmentService establishmentService)
        {
            this.orderService = orderService;
            this.establishmentService = establishmentService;
            this.locationService = locationService;
            this.userService = userService;
            this.cache = cache;
            this.hub = hub;
            observer = new OrdersObserver(notificationsObservable, hub, cache, orderService);
        }

        public IActionResult Index()
        {
            var exists = CheckAuth();
            if (exists)
            {
                var user = HttpContext.Session.Get();

                // Cache current establishment.
                var establishment = establishmentService.GetById(user.EstablishmentId);

                // Fetch current unpaid orders.
                observer.Register(establishment.Id);

                List<OrderModel> orders = orderService.GetUnpaidOrdersForEstablishmentId(establishment.Id)
                    .OrderByDescending(o => o.Date)
                    .Select(order => new OrderModel
                    {
                        Id = order.Id,
                        Date = order.Date,
                        Paid = order.Paid,
                        Price = order.Price,
                        OrderedProducts = order.OrderedProducts,
                        Customer = order.CustomerId,
                        Employee = HttpContext.Session.Get().Username,
                        Location = establishment.Locations.First(l => l.Id == order.LocationId),
                        Establishment = establishment
                    })
                    .ToList();

                // Cache orders and establishment
                cache.Set("orders",orders);
                cache.Set("establishment", establishment);
                cache.Set("user", user);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult About()
        {

            var exists = CheckAuth();
            if (!exists)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewData["Message"] = "Your application description page.";
                return View();
            }

        }

        public IActionResult Contact()
        {
            var exists = CheckAuth();
            if (!exists)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewData["Message"] = "Your contact page.";
                return View();
            }

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Partial(long id)
        {
            // Find requested order
            var establishment = cache.Get<Establishment>("establishment");
            var order = GetOrderFromCache(id);

            return PartialView("OrderDetailsPartial", order);
        }

        private Boolean CheckAuth()
        {
            var credentials = HttpContext.Session.Get();
            return credentials != null;
        }

        public IActionResult Pay(long id)
        {
            var order = GetOrderFromCache(id);
            orderService.SetPaid(id);
            RemoveOrderFromCache(id);
            hub.Send("PAID", order.Location.Name);
            return StatusCode(200);
        }

        public IActionResult QRGenerator()
        {
            var establishment = cache.Get<Establishment>("establishment");
            var locations = establishment.Locations;
            return View(locations);
        }

        private OrderModel GetOrderFromCache(long id)
        {
            var orders = cache.Get<List<OrderModel>>("orders");
            var order = orders.Find(o => o.Id == id);
            return order;
        }

        private void RemoveOrderFromCache(long id)
        {
            var orders = cache.Get<List<OrderModel>>("orders");
            orders.RemoveAll(o => o.Id == id);
            cache.Set("orders", orders);
        }

        [HttpGet]
        public JsonResult Orders()
        {
            var orders = cache.Get<List<OrderModel>>("orders");
            return Json(orders);
        }

    }
}
