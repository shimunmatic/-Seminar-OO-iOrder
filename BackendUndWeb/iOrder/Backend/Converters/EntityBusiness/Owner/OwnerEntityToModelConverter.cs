using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class OwnerEntityToModelConverter : IConverter<OwnerEntity, Owner>
    {
        public Owner Convert(OwnerEntity Source)
        {
            if (null == Source) return null;
            return new Owner
            {
                Username = Source.Username,
                Zip = Source.Zip,
                Address = Source.Address,
                City = Source.City,
                Email = Source.Email,
                Password = Source.Password,
                PhoneNumber = Source.PhoneNumber,
                Role = null
            };
        }

        public IEnumerable<Owner> Convert(IEnumerable<OwnerEntity> Source)
        {
            if (null == Source) return null;
            var owners = new List<Owner>();
            foreach (var o in Source)
            {
                owners.Add(new Owner
                {
                    Username = o.Username,
                    Zip = o.Zip,
                    Address = o.Address,
                    City = o.City,
                    Email = o.Email,
                    Password = o.Password,
                    PhoneNumber = o.PhoneNumber,
                    Role = null

                });
            }
            return owners;
        }
    }
}
