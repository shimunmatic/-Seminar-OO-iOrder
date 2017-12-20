using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Converters.EntityBusiness.Interface;
using Backend.Models.Business;
using Backend.Models.Entity;

namespace Backend.Converters.EntityBusiness.Implementation
{
    public class RoleConverter: IRoleConverter
    {
        public IEnumerable<Role> convert(IEnumerable<RoleEntity> roles)
        {
            List<Role> roleList = new List<Role>();
            foreach (var entity in roles)
            {
                Role role = new Role();
                role.Id = entity.Id;
                role.RoleName = entity.RoleName;
                roleList.Add(role);
            }
            return roleList;


        }
    }
}
