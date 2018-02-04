using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class SupplierEntityToModelConverter : IConverter<SupplierEntity, Supplier>
    {
        public Supplier Convert(SupplierEntity Source)
        {
            if (null == Source) return null;
            return new Supplier
            {
                Id = Source.Id,
                Email = Source.Email,
                Name = Source.Name,
                OwnerId = Source.OwnerId,
                PhoneNumber = Source.PhoneNumber
            };
        }

        public IEnumerable<Supplier> Convert(IEnumerable<SupplierEntity> Source)
        {
            if (null == Source) return null;
            var entites = new List<Supplier>();
            foreach (var s in Source)
            {
                entites.Add(new Supplier
                {
                    Id = s.Id,
                    Email = s.Email,
                    Name = s.Name,
                    OwnerId = s.OwnerId,
                    PhoneNumber = s.PhoneNumber
                });
            }
            return entites;
        }
    }
}
