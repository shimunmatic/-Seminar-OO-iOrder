using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class EstablishmentModelToEntityConveter : IConverter<Establishment, EstablishmentEntity>
    {
        public EstablishmentEntity Convert(Establishment Source)
        {
            if (null == Source) return null;
            return new EstablishmentEntity
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

        public IEnumerable<EstablishmentEntity> Convert(IEnumerable<Establishment> Source)
        {
            if (null == Source) return null;
            var entites = new List<EstablishmentEntity>();
            foreach (var e in Source)
            {
                entites.Add(new EstablishmentEntity
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
