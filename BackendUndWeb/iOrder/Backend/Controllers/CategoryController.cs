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
    [Route("api/Category")]
    [Authorize]
    public class CategoryController : Controller
    {
        private ICategoryService CategoryService;

        public CategoryController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        // GET: api/Category/Warehouse/5
        [HttpGet("Warehouse/{id}", Name = "GetCategoriesForWarehouse")]
        [Authorize(Roles = "ADMIN")]
        public IEnumerable<Category> GetCategoriesForWarehouse(int id)
        {
            return CategoryService.GetAllForWarehouseId(id);
        }

        // GET: api/Category
        [HttpGet(Name = "GetCategoriesForOwner")]
        [Authorize(Roles = "ADMIN")]
        public IEnumerable<Category> GetCategoriesForOwner()
        {
            return CategoryService.GetAllForOwner(User.Identity.Name);
        }

        // POST: api/Category
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public void Post([FromBody]Category category)
        {
            category.OwnerId = User.Identity.Name;
            CategoryService.Save(category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public void Put(int id, [FromBody]Category value)
        {
            CategoryService.Update(id, value);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public void Delete(int id)
        {
            CategoryService.Delete(id);
        }
    }
}
