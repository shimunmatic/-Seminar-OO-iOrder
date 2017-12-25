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

        public IEnumerable<Role> GetAll()
        {
            return RoleRepository.GetAll();
        }

        public Role GetById(long Id)
        {
            return RoleRepository.GetById(Id);
        }

        public Role GetByName(string name)
        {
            return RoleRepository.GetByName(name);
        }
    }
}
