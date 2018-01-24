using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using Backend.Models.ModelView;

namespace Frontend.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            var exists = CheckAuth();
            if (exists)
            {
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

        private Boolean CheckAuth()
        {
            var credentials = HttpContext.Session.Get();
            return credentials != null;
        }
    }
}
