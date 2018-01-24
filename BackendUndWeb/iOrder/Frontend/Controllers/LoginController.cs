using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.ModelView;
using Backend.Services.Implementation;
using Backend.Services.Interface;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class LoginController : Controller
    {

        private IUserService userService;

        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserCredentials login)
        {
            //var exists = userService.ValidateUserCredentials(login);
            var exists = true;
            if (exists)
            {
                HttpContext.Session.Set(login);
                return RedirectToAction("Index", "Orders");
                
            }
            else
            {
                return StatusCode(404);
            }

        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(Default.KEY);
            return RedirectToAction("Index", "Login");
        }
    }
}