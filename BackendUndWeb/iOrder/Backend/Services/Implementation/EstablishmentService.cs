using Backend.Models.Business;
using Backend.Repositories.Interface;
using Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Implementation
{
    public class EstablishmentService : IEstablishmentService
    {
        private ICategoryService CategoryService;
        private ILocationService LocationService;
        private IEstablishmentRepository EstablishmentRepository;

        public EstablishmentService(ICategoryService categoryService, ILocationService locationService, IEstablishmentRepository establishmentRepository)
        {
            CategoryService = categoryService;
            LocationService = locationService;
            EstablishmentRepository = establishmentRepository;
        }

        public void Delete(object id)
        {
            EstablishmentRepository.Delete(EstablishmentRepository.GetById(id));
        }

        public IEnumerable<Establishment> GetAll()
        {
            var establishments = EstablishmentRepository.GetAll();
            foreach (var establishment in establishments)
            {
                establishment.Categories = CategoryService.GetAllForWarehouseId(establishment.WarehouseId);
                establishment.Locations = LocationService.GetLocationsForEstablishmentId(establishment.Id);
            }
            return establishments;
        }

        public IEnumerable<Establishment> GetAllForOwner(string username)
        {
            var establishments = EstablishmentRepository.GetEstablishmentsForOwner(username);
            foreach (var establishment in establishments)
            {
                establishment.Categories = CategoryService.GetAllForWarehouseId(establishment.WarehouseId);
                establishment.Locations = LocationService.GetLocationsForEstablishmentId(establishment.Id);
            }
            return establishments;
        }

        public Establishment GetById(object id)
        {
            var establishment = EstablishmentRepository.GetById(id);
            establishment.Categories = CategoryService.GetAllForWarehouseId(establishment.WarehouseId);
            establishment.Locations = LocationService.GetLocationsForEstablishmentId((long)id);
            return establishment;

        }

        public void Save(Establishment t)
        {
            EstablishmentRepository.Save(t);
        }

        public void Update(object id, Establishment t)
        {
            EstablishmentRepository.Update(id, t);
        }
    }
}
