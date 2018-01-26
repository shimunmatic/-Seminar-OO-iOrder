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

namespace Frontend.Controllers
{
    public class OrdersController : Controller
    {

        private IOrderService orderService;
        private ILocationService locationService;
        private IEstablishmentService establishmentService;
        private IUserService userService;
        private IMemoryCache cache;

        public OrdersController(IMemoryCache cache, IOrderService orderService, IUserService userService, ILocationService locationService,IEstablishmentService establishmentService)
        {
            this.orderService = orderService;
            this.establishmentService = establishmentService;
            this.locationService = locationService;
            this.userService = userService;
            this.cache = cache;

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
                var orders = orderService.GetUnpaidOrdersForEstablishmentId(establishment.Id).OrderByDescending(o => o.Date).ToList();
                // Cache orders and establishment
                cache.Set("orders",orders);
                cache.Set("establishment", establishment);

                return View(orders);
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

            // Build corresponding order model for view.
            var orderModel = new OrderModel
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
            };
            return PartialView("OrderDetailsPartial", orderModel);
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

            ViewBag.PaidSuccessfully = "Order was processed";
            return StatusCode(200);
        }

        public IActionResult Bill(long id)
        {
            var order = GetOrderFromCache(id);
            return StatusCode(200);
        }

        public IActionResult QRGenerator()
        {
            return View();
        }

        private Order GetOrderFromCache(long id)
        {
            var orders = cache.Get<List<Order>>("orders");
            var order = orders.Find(o => o.Id == id);
            return order;
        }

        private void RemoveOrderFromCache(long id)
        {
            var orders = cache.Get<List<Order>>("orders");
            orders.RemoveAll(o => o.Id != id);
            cache.Set("orders", orders);
        }
    }
}
