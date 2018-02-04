using Backend.Models.Business;
using Backend.Repositories.Interface;
using Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Implementation
{
    public class LocationService : ILocationService
    {
        private ILocationRepository LocationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            LocationRepository = locationRepository;
        }

        public void Delete(object id)
        {
            LocationRepository.Delete(LocationRepository.GetById(id));
        }

        public IEnumerable<Location> GetAll()
        {
            return LocationRepository.GetAll();
        }

        public Location GetById(object id)
        {
            return LocationRepository.GetById(id);
        }

        public IEnumerable<Location> GetLocationsForEstablishmentId(long id)
        {
            return LocationRepository.GetLocationsForEstablishment(id);
        }

        public IEnumerable<Location> GetLocationsForOwner(string username)
        {
            return LocationRepository.GetLocationsForOwnerId(username);
        }

        public void Save(Location t)
        {
            LocationRepository.Save(t);
        }

        public void Update(object id, Location t)
        {
            LocationRepository.Update(id, t);
        }
    }
}
