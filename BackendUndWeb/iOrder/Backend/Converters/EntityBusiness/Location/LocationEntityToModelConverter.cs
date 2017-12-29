using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class LocationEntityToModelConverter : IConverter<LocationEntity, Location>
    {
        public Location Convert(LocationEntity Source)
        {
            if (null == Source) return null;
            return new Location
            {
                Id = Source.Id,
                EstablishmentId = Source.EstablishmentId,
                Name = Source.Name
            };
        }

        public IEnumerable<Location> Convert(IEnumerable<LocationEntity> Source)
        {
            if (null == Source) return null;
            var locations = new List<Location>();
            foreach (var l in Source)
            {
                locations.Add(new Location
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
