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
    [Route("api/Product")]
    [Authorize]
    public class ProductController : Controller
    {
        private IProductService ProductService;

        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var name = User.Identity.Name;

            return ProductService.GetProductsForOwnerId(name);
        }

        // POST: api/Product
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public void Post([FromBody]Product product)
        {
            product.OwnerId = User.Identity.Name;
            ProductService.Save(product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product product)
        {
            ProductService.Update(id, product);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProductService.Delete(id);
        }
    }
}
