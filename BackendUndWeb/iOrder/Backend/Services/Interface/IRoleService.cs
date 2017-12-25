using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Interface
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAll();
        Role GetById(long Id);
        Role GetByName(string name);
    }
}
