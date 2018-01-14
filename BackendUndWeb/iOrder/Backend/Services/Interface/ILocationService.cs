using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Interface
{
    public interface ILocationService : IBaseService<Location>
    {
        IEnumerable<Location> GetLocationsForEstablishmentId(long id);
        IEnumerable<Location> GetLocationsForOwner(string username);

    }
}
