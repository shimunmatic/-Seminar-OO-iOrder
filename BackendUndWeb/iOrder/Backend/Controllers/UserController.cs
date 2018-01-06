using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Business;
using Backend.Models.ModelView;
using Backend.Repositories.Interface;
using Backend.Services.Interface;
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

        //POST: api/User/Get
        [HttpPost("Get")]
        public User GetUser([FromBody]UserCredentials credentials)
        {
            return UserService.Get(credentials.Username, credentials.Password);
        }

        // POST: api/User/Register
        [HttpPost("Register")]
        public IActionResult Post([FromBody]User user)
        {
            var u = UserService.Register(user);
            if (u != null) return Ok();
            return BadRequest();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
