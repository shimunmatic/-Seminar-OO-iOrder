using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Business;
using Backend.Models.Entity;

namespace Backend.Converters.EntityBusiness.Interface
{
    public interface IRoleConverter
    {
        IEnumerable<Role> convert(IEnumerable<RoleEntity> roles);
    }
}
