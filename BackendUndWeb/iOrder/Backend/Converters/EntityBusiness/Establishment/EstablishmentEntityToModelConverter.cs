using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class EstablishmentEntityToModelConverter : IConverter<EstablishmentEntity, Establishment>
    {
        public Establishment Convert(EstablishmentEntity Source)
        {
            if (null == Source) return null;
            return new Establishment
            {
                Id = Source.Id,
                WarehouseId = Source.WarehouseId,
                Address = Source.Address,
                City = Source.City,
                Zip = Source.Zip,
                Name = Source.Name,
                OwnerId = Source.OwnerId
            };
        }

        public IEnumerable<Establishment> Convert(IEnumerable<EstablishmentEntity> Source)
        {
            if (null == Source) return null;
            var entites = new List<Establishment>();
            foreach (var e in Source)
            {
                entites.Add(new Establishment
                {
                    Id = e.Id,
                    WarehouseId = e.WarehouseId,
                    Address = e.Address,
                    City = e.City,
                    Zip = e.Zip,
                    Name = e.Name,
                    OwnerId = e.OwnerId
                });
            }
            return entites;
        }
    }
}
