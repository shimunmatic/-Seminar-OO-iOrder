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

        public IEnumerable<Location> GetLocationsForEstablishmentId(long id)
        {
            return LocationRepository.GetLocationsForEstablishment(id);
        }
    }
}
