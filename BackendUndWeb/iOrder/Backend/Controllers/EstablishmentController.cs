﻿using System;
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
    [Route("api/Establishment")]
    [Authorize]
    public class EstablishmentController : Controller
    {
        private IEstablishmentService EstablishmentService;

        public EstablishmentController(IEstablishmentService establishmentService)
        {
            EstablishmentService = establishmentService;
        }


        // GET: api/Establishment
        [HttpGet]
        public IEnumerable<Establishment> Get()
        {
            return EstablishmentService.GetAll();
        }

        // GET: api/Establishment/5
        [HttpGet("Owner", Name = "GetEstablishmentsForOwner")]
        public IEnumerable<Establishment> GetForOwner()
        {
            return EstablishmentService.GetAllForOwner(User.Identity.Name);
        }


        // GET: api/Establishment/5
        [HttpGet("{id}", Name = "GetEstablishment")]
        public Establishment Get(int id)
        {
            return EstablishmentService.GetById(id);
        }

        // POST: api/Establishment
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public void Post([FromBody]Establishment establishment)
        {
            establishment.OwnerId = User.Identity.Name;
            EstablishmentService.Save(establishment);
        }

        // PUT: api/Establishment/5
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
