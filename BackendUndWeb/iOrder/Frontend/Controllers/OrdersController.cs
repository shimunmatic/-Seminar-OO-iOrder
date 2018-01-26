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

namespace Frontend.Controllers
{
    public class OrdersController : Controller
    {

        private IOrderService orderService;
        private ILocationService locationService;
        private IEstablishmentService establishmentService;
        private IUserService userService;

        public OrdersController(IOrderService orderService, IUserService userService, ILocationService locationService,IEstablishmentService establishmentService)
        {
            this.orderService = orderService;
            this.establishmentService = establishmentService;
            this.locationService = locationService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var exists = CheckAuth();
            if (exists)
            {
                var user = HttpContext.Session.Get();
                var orders = orderService.GetUnpaidOrdersForEstablishmentId(user.EstablishmentId.GetValueOrDefault());
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
            Debug.WriteLine(id);
            var order = orderService.GetById(id);
            var realOrder = new OrderModel
            {
                Id = order.Id,
                Date = order.Date,
                Paid = order.Paid,
                Price = order.Price,
                OrderedProducts = order.OrderedProducts,
                Customer = userService.GetById(order.CustomerId),
                Employee = HttpContext.Session.Get().Username,
                Location = locationService.GetById(order.LocationId),
                Establishment = establishmentService.GetById(order.EstablishmentId) 
            };

            return PartialView("OrderDetailsPartial",realOrder);
        }

        private Boolean CheckAuth()
        {
            var credentials = HttpContext.Session.Get();
            return credentials != null;
        }
    }
}
