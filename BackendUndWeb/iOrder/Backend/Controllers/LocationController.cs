using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Business;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Location")]
    [Authorize(Roles = "ADMIN")]
    public class LocationController : Controller
    {
        private ILocationService LocationService;

        public LocationController(ILocationService locationService)
        {
            LocationService = locationService;
        }

        // GET: api/Location
        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return LocationService.GetLocationsForOwner(User.Identity.Name);
        }

        // POST: api/Location
        [HttpPost]
        public void Post([FromBody]Location location)
        {
            LocationService.Save(location);
        }

        // PUT: api/Location/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody]Location location)
        {
            LocationService.Update(id, location);
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            LocationService.Delete(id);
        }
    }
}
