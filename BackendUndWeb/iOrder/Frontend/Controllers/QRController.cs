using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Business;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Frontend.Controllers
{
    public class QRController : Controller
    {
        private IMemoryCache cache;

        public QRController(IMemoryCache cache)
        {
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
                var establishment = cache.Get<Establishment>("establishment");
                var locations = establishment.Locations;
                return View(locations);
            }
        }

        private Boolean CheckAuth()
        {
            var credentials = HttpContext.Session.Get();
            return credentials != null;
        }
    }
}