using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Business;
using Backend.Models.Entity;

namespace Backend.Repositories.Interface
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
        Role Save(Role role);
        Role Update(long Id, Role role);
        bool Delete(Role role);

        Role GetById(long Id);

        Role GetByName(string name);


    }
}
