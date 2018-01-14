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
    [Route("api/Warehouse")]
    [Authorize(Roles = "ADMIN")]
    public class WarehouseController : Controller
    {
        private IWarehouseService WarehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            WarehouseService = warehouseService;
        }

        // GET: api/Warehouse
        [HttpGet]
        public IEnumerable<Warehouse> Get()
        {
            return WarehouseService.GetWarehousesForOwner(User.Identity.Name);
        }

        // POST: api/Warehouse
        [HttpPost]
        public void Post([FromBody]Warehouse warehouse)
        {
            warehouse.OwnerId = User.Identity.Name;
            WarehouseService.Save(warehouse);

        }

        // PUT: api/Warehouse/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Warehouse warehouse)
        {
            WarehouseService.Update(id, warehouse);

        }

        // DELETE: api/Warehouse/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            WarehouseService.Delete(id);
        }
    }
}
