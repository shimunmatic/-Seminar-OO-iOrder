using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Backend.Models.ModelView;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
            var valid = UserService.ValidateUserCredentials(credentials);
            if (!valid)
            {
                return Unauthorized();
            }
            var user = UserService.Get(credentials.Username);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, credentials.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.Role.RoleName)
            };

            var token = new JwtSecurityToken
            (
                issuer: "iOrder.fer.hr",
                audience: "iOrder.fer.hr",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(60),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("System.ArgumentOutOfRangeException")),
                    SecurityAlgorithms.HmacSha256)
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

    }
}
