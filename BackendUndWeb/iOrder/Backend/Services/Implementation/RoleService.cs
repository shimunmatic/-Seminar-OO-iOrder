using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Business;
using Backend.Repositories.Interface;
using Backend.Services.Interface;

namespace Backend.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private IRoleRepository RoleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            RoleRepository = roleRepository;
        }

        public void Delete(object id)
        {
            RoleRepository.Delete(RoleRepository.GetById(id));
        }

        public IEnumerable<Role> GetAll()
        {
            return RoleRepository.GetAll();
        }

        public Role GetById(object Id)
        {
            return RoleRepository.GetById(Id);
        }

        public Role GetByName(string name)
        {
            return RoleRepository.GetByName(name);
        }

        public void Save(Role t)
        {
            RoleRepository.Save(t);
        }

        public void Update(object id, Role t)
        {
            RoleRepository.Update(id, t);
        }
    }
}
