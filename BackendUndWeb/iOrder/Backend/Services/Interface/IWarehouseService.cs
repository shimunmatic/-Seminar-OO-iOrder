using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Interface
{
    public interface IWarehouseService : IBaseService<Warehouse>
    {
        IEnumerable<Warehouse> GetWarehousesForOwner(string username);
        int GetQuantityForProductInWarehouse(long productId, long warehouseId);
    }
}
