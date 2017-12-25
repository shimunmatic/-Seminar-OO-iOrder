using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class RoleModelToEntityConverter : IConverter<Role, RoleEntity>
    {
        public RoleEntity Convert(Role Source)
        {
            if (null == Source) return null;
            return new RoleEntity
            {
                Id = Source.Id,
                RoleName = Source.RoleName
            };
        }

        public IEnumerable<RoleEntity> Convert(IEnumerable<Role> Source)
        {
            if (null == Source) return null;
            List<RoleEntity> list = new List<RoleEntity>();
            foreach (var role in Source)
            {
                list.Add(new RoleEntity
                {
                    Id = role.Id,
                    RoleName = role.RoleName
                });
            }
            return list;
        }
    }
}
