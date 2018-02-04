using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class WarehouseModelToEntityConverter : IConverter<Warehouse, WarehouseEntity>
    {
        public WarehouseEntity Convert(Warehouse Source)
        {
            if (null == Source) return null;
            return new WarehouseEntity
            {

                Id = Source.Id,
                Address = Source.Address,
                City = Source.City,
                Zip = Source.Zip,
                OwnerId = Source.OwnerId
            };
        }

        public IEnumerable<WarehouseEntity> Convert(IEnumerable<Warehouse> Source)
        {
            if (null == Source) return null;
            var whouses = new List<WarehouseEntity>();
            foreach (var w in Source)
            {
                whouses.Add(new WarehouseEntity
                {
                    Id = w.Id,
                    Address = w.Address,
                    City = w.City,
                    Zip = w.Zip,
                    OwnerId = w.OwnerId
                });
            }
            return whouses;
        }
    }
}
