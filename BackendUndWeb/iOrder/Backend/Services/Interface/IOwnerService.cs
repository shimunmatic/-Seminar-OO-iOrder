using Backend.Models.Business;
using Backend.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Interface
{
    public interface IOwnerService
    {
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(UserCredentials credentials);
    }
}
