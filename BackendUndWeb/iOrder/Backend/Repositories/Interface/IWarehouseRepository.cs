using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.Interface
{
    public interface IWarehouseRepository:IBaseRepository<Warehouse>
    {
        IEnumerable<Warehouse> GetWearhousesForOwner(string Username);
    }
}
