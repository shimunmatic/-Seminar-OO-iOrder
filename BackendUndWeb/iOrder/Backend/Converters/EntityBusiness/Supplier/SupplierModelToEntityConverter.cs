using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class SupplierModelToEntityConverter : IConverter<Supplier, SupplierEntity>
    {
        public SupplierEntity Convert(Supplier Source)
        {
            if (null == Source) return null;
            return new SupplierEntity
            {
                Id = Source.Id,
                Email = Source.Email,
                Name = Source.Name,
                OwnerId = Source.OwnerId,
                PhoneNumber = Source.PhoneNumber
            };
        }

        public IEnumerable<SupplierEntity> Convert(IEnumerable<Supplier> Source)
        {
            if (null == Source) return null;
            var entites = new List<SupplierEntity>();
            foreach (var s in Source)
            {
                entites.Add(new SupplierEntity
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
