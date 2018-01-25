﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Business;
using Backend.Models.ModelView;
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
        [Authorize(Roles = ("ADMIN"))]
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
        [Authorize(Roles = "ADMIN")]
        public void Put(long id, [FromBody]Product product)
        {
            ProductService.Update(id, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public void Delete(long id)
        {
            ProductService.Delete(id);
        }

        // POST: api/Product/Storage
        [HttpPost("Storage")]
        [Authorize(Roles = "ADMIN")]
        public void AddProductToWarehouse([FromBody]WarehouseProduct warehouseProduct)
        {
            ProductService.AddProductToWarehouse(warehouseProduct.ProductId, warehouseProduct.WarehouseId, warehouseProduct.Quantity, warehouseProduct.SellingPrice);
        }

        // GET: api/Product/Storage/1
        [HttpGet("Storage/{warehouseId}")]
        [Authorize(Roles = ("ADMIN"))]
        public IEnumerable<Product> GetProductsForWarehouse(long warehouseId)
        {
            return ProductService.GetProductsForWarehouseId(warehouseId);
        }

    }
}
