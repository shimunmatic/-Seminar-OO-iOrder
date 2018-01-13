using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Interface
{
    public interface IRoleService : IBaseService<Role>
    {
        Role GetByName(string name);
    }
}
