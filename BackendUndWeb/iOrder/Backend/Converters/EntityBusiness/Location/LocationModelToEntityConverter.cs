using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class LocationModelToEntityConverter : IConverter<Location, LocationEntity>
    {
        public LocationEntity Convert(Location Source)
        {
            if (null == Source) return null;
            return new LocationEntity
            {
                Id = Source.Id,
                EstablishmentId = Source.EstablishmentId,
                Name = Source.Name
            };
        }

        public IEnumerable<LocationEntity> Convert(IEnumerable<Location> Source)
        {
            if (null == Source) return null;
            var locations = new List<LocationEntity>();
            foreach (var l in Source)
            {
                locations.Add(new LocationEntity
                {
                    Id = l.Id,
                    EstablishmentId = l.EstablishmentId,
                    Name = l.Name
                });
            }
            return locations;
        }
    }
}
