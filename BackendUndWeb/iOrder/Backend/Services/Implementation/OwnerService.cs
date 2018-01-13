using Backend.Models.Business;
using Backend.Models.ModelView;
using Backend.Repositories.Interface;
using Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Implementation
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository OwnerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            OwnerRepository = ownerRepository;
        }

        public void Delete(object id)
        {
            OwnerRepository.Delete(OwnerRepository.GetById(id));
        }

        public IEnumerable<Owner> GetAll()
        {
            return OwnerRepository.GetAll();
        }

        public Owner GetById(object id)
        {
            return OwnerRepository.GetById(id);
        }

        public void Save(Owner t)
        {
            OwnerRepository.Save(t);
        }

        public void Update(object id, Owner t)
        {
            OwnerRepository.Update(id, t);
        }
    }
}
