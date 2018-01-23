using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            // return login form
            return View();
        }

        public IActionResult Login()
        {

            //try login here
            //if failed redirect to home
            //else return error
            return View();
        }
    }
}