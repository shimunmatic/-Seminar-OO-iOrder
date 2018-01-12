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

        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetProduct")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Product
        [HttpPost]
        public void Post([FromBody]Product product)
        {
            ProductService.Save(product);
        }
        
        // PUT: api/Product/5
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
