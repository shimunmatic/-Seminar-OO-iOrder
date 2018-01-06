using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.ModelView;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private IUserService UserService;

        public AuthController(IUserService userService)
        {
            UserService = userService;
        }


        // POST: api/Auth
        [HttpPost]
        public IActionResult Post([FromBody]UserCredentials credentials)
        {
            if (!UserService.ValidateUserCredentials(credentials))
                return Unauthorized();
            //TODO create token and return it

            return Ok();
        }

    }
}
