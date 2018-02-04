using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Business;
using Backend.Services.Interface;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Frontend.Views
{
    public class HistoryController : Controller
    {

        private IOrderService orderService;
        private IUserService userService;
        private IMemoryCache cache;

        public HistoryController(IMemoryCache cache, IOrderService orderService, IUserService userService)
        {
            this.orderService = orderService;
            this.userService = userService;
            this.cache = cache;
        }

        public IActionResult Index()
        {
            var exists = CheckAuth();
            if (!exists)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                User user = HttpContext.Session.Get();
                var establishment = cache.Get<Establishment>("establishment");

                List<OrderModel> orders = orderService.GetHistoryEstablishmentId(user.EstablishmentId.Value)
                    .OrderByDescending(o => o.Date)
                    .Select(order => new OrderModel
                    {
                        Id = order.Id,
                        Date = order.Date,
                        Paid = order.Paid,
                        Price = order.Price,
                        OrderedProducts = order.OrderedProducts,
                        Customer = order.CustomerId,
                        // get real employee, not currently logged in
                        Employee = order.EmployeeId != null ? userService.GetById(order.EmployeeId).Username : user.Username,
                        Location = establishment.Locations.First(l => l.Id == order.LocationId),
                        Establishment = establishment
                    })
                    .ToList();
                cache.Set("ordershistory", orders);
                return View(orders);
            }
        }

        private Boolean CheckAuth()
        {
            var credentials = HttpContext.Session.Get();
            return credentials != null;
        }

        public IActionResult Partial(long id)
        {
            // Find requested order
            var orders = cache.Get<List<OrderModel>>("ordershistory");
            var order = orders.Find(o => o.Id == id);
            return PartialView("OrderDetailsPartial", order);
        }

        public IActionResult HistoryPartial()
        {
            var orders = cache.Get<List<OrderModel>>("ordershistory");

            var dict = new Dictionary<long, HistoryTripleModel>();
            orders.ForEach(o => {
                o.OrderedProducts.ToList().ForEach(p => {
                    if (dict.ContainsKey(p.Product.Id))
                    {
                        // update triple
                        try
                        {
                            HistoryTripleModel temp;
                            dict.TryGetValue(p.Product.Id, out temp);
                            temp.count = temp.count + p.Quantity;
                            temp.totalPrice = temp.totalPrice + temp.price*p.Quantity;
                            dict[p.Product.Id] = temp;
                        }
                        catch (ArgumentNullException)
                        {
                            // stupid catch, YAGNI
                        }

                    }
                    else
                    {
                        var triple = new HistoryTripleModel()
                        {
                            name = p.Product.Name,
                            count = p.Quantity,
                            price = p.Product.SellingPrice,
                            totalPrice = p.Product.SellingPrice * p.Quantity
                        };
                        dict[p.Product.Id] = triple;
                    }
                });
            });

            var history = new HistoryModel()
            {
                triples = dict.Values.ToList(),
                totalExpense = dict.Values.Select(p => p.totalPrice).Sum()
            };
            return PartialView("HistoryPartial", history);
        }
    }
}