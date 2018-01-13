using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Produces("text/plain")]
    [Route("")]
    public class HomeController : Controller
    {
        // GET: /
        [HttpGet]
        public string Get()
        {
            return "Welcome to iOrder Backend Server\n" +
                "Team:\n" +
                "Borna Grgić\n" +
                "Shimun Matić\n" +
                "Martin Mihalić\n" +
                "Matija Vukić\n\n\n" +
                "BEST Team EVEER! ;)";
        }
    }
}