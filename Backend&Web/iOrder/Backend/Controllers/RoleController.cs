using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Entity;
using Backend.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Role")]
    public class RoleController : Controller
    {
        private IRoleRepository Repository;

        public RoleController(IRoleRepository repository)
        {
            Repository = repository;
        }

        // GET: api/Role
        [HttpGet]
        public IEnumerable<RoleEntity> Get() => Repository.GetAll();

        // GET: api/Role/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Role
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}