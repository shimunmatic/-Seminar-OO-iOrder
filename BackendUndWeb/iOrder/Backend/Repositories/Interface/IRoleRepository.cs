using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Business;
using Backend.Models.Entity;

namespace Backend.Repositories.Interface
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Role GetByName(string name);
    }
}
