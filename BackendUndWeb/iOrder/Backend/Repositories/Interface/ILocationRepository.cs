using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.Interface
{
    public interface ILocationRepository:IBaseRepository<Location>
    {
        IEnumerable<Location> GetLocationsForEstablishment(long Id);
        IEnumerable<Location> GetLocationsForOwnerId(string username);

    }
}
