using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.ModelView;
using Backend.Notifications.Observable;
using Backend.Notifications.Observer;
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
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var exists = userService.ValidateUserCredentials(new UserCredentials {
                    Username = login.Username,
                    Password = login.Password
                });
                if (exists)
                {
                    var user = userService.GetById(login.Username);
                    if(user.EstablishmentId == null)
                    {
                        ViewBag.NoUser = "User is not an employee.";
                        return View("Index", login);
                    }
                    else
                    {
                        HttpContext.Session.Set(user);
                        return RedirectToAction("Index", "Orders");
                    }
                }
                else
                {
                    ViewBag.NoUser = "No such user.";
                    return View("Index",login);
                }
            }
            else
            {
                return View("Index",login);
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