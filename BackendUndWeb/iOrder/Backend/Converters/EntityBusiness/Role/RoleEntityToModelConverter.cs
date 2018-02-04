using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Business;
using Backend.Models.Entity;

namespace Backend.Converters.EntityBusiness
{
    public class RoleEntityToModelConverter : IConverter<RoleEntity, Role>
    {
        public Role Convert(RoleEntity Source)
        {
            if (null == Source) return null;
            Role role = new Role
            {
                Id = Source.Id,
                RoleName = Source.RoleName
            };
            return role;

        }

        public IEnumerable<Role> Convert(IEnumerable<RoleEntity> Source)
        {
            if (null == Source) return null;
            List<Role> roleList = new List<Role>();
            foreach (var entity in Source)
            {
                Role role = new Role
                {
                    Id = entity.Id,
                    RoleName = entity.RoleName
                };
                roleList.Add(role);
            }
            return roleList;
        }
    }
}
