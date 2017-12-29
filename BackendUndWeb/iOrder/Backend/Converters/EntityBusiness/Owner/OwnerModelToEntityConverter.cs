using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class OwnerModelToEntityConverter : IConverter<Owner, OwnerEntity>
    {
        public OwnerEntity Convert(Owner Source)
        {
            if (null == Source) return null;
            return new OwnerEntity
            {
                Username = Source.Username,
                Zip = Source.Zip,
                Address = Source.Address,
                City = Source.City,
                Email = Source.Email,
                Password = Source.Password,
                PhoneNumber = Source.PhoneNumber,
                RoleId = Source.Role.Id
            };
        }

        public IEnumerable<OwnerEntity> Convert(IEnumerable<Owner> Source)
        {
            if (null == Source) return null;
            var owners = new List<OwnerEntity>();
            foreach (var o in Source)
            {
                owners.Add(new OwnerEntity
                {
                    Username = o.Username,
                    Zip = o.Zip,
                    Address = o.Address,
                    City = o.City,
                    Email = o.Email,
                    Password = o.Password,
                    PhoneNumber = o.PhoneNumber,
                    RoleId = o.Role.Id

                });
            }
            return owners;
        }
    }
}
