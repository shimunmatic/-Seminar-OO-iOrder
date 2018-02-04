using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Business;
using Backend.Models.ModelView;
using Backend.Repositories.Interface;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        //GET: api/User/Employee
        [HttpGet("Employee")]
        [Authorize(Roles = "ADMIN")]
        public IEnumerable<User> GetEmployees()
        {
            var name = User.Identity.Name;
            Console.WriteLine();
            return UserService.GetAllEmployeesForOwner(name);
        }

        //GET: api/User/Employee
        [HttpGet("Admin")]
        [Authorize(Roles = "GOD")]
        public IEnumerable<User> GetAdmins()
        {
            return UserService.GetAllAdmins();
        }

        // POST: api/User/Customer
        [HttpPost("Customer")]
        [AllowAnonymous]
        public void PoCreateCustomer([FromBody]User user)
        {
            UserService.RegisterCustomer(user);

        }

        // POST: api/User/Employee
        [HttpPost("Employee")]
        [Authorize(Roles = "ADMIN")]
        public void CreateEmployee([FromBody]User user)
        {
            user.OwnerId = User.Identity.Name;
            UserService.RegisterEmployee(user);

        }

        // POST: api/User/Admin
        [HttpPost("Admin")]
        [Authorize(Roles = "GOD")]
        public void CreateAdmin([FromBody]User user)
        {
            UserService.RegisteAdmin(user);

        }


        // DELETE: api/User/Customer
        [HttpDelete("Customer")]
        [Authorize(Roles = "CUSTOMER")]
        public void DeleteCustomer()
        {
            UserService.Delete(User.Identity.Name);
        }


        // DELETE: api/User/Employee/shemso
        [HttpDelete("Employee/{username}")]
        [Authorize(Roles = "ADMIN")]
        public void DeleteEmployee(string username)
        {
            UserService.Delete(username);
        }

        // DELETE: api/User/Admin/shemso
        [HttpDelete("Admin/{username}")]
        [Authorize(Roles = "GOD")]
        public void DeleteAdmin(string username)
        {
            UserService.Delete(username);
        }
    }
}
