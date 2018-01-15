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
    [Route("api/Supplier")]
    [Authorize(Roles = "ADMIN")]
    public class SupplierController : Controller
    {
        private ISupplierService SupplierService;

        public SupplierController(ISupplierService supplierService)
        {
            SupplierService = supplierService;
        }

        // GET: api/Supplier
        [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            return SupplierService.GetSuppliersForOwner(User.Identity.Name);
        }

        // POST: api/Supplier
        [HttpPost]
        public void Post([FromBody]Supplier supplier)
        {
            SupplierService.Save(supplier);
        }

        // PUT: api/Supplier/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody]Supplier supplier)
        {
            SupplierService.Update(id, supplier);
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            SupplierService.Delete(id);
        }
    }
}
