using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Entity;

namespace Backend.Repositories.Interface
{
    public interface IRoleRepository
    {
        IEnumerable<RoleEntity> GetAll();
    }
}
