using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class WarehouseEntityToModelConverter : IConverter<WarehouseEntity, Warehouse>
    {
        public Warehouse Convert(WarehouseEntity Source)
        {
            if (null == Source) return null;
            return new Warehouse
            {

                Id = Source.Id,
                Address = Source.Address,
                City = Source.City,
                Zip = Source.Zip,
                OwnerId = Source.OwnerId
            };
        }

        public IEnumerable<Warehouse> Convert(IEnumerable<WarehouseEntity> Source)
        {
            if (null == Source) return null;
            var whouses = new List<Warehouse>();
            foreach (var w in Source)
            {
                whouses.Add(new Warehouse
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
