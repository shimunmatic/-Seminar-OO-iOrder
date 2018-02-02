using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.Interface
{
    public interface IWarehouseRepository : IBaseRepository<Warehouse>
    {
        IEnumerable<Warehouse> GetWearhousesForOwner(string Username);
        int GetQuantityForProductInWarehouse(long productId, long warehouseId);
        void AddProductToWarehouse(WarehouseProductEntity entity);
        int ReduceProductQuantityFromWarehouse(long productId, long warehouseId, int quantity);
        void AddProductQuantityToWarehouse(long id, long warehouseId, int quantity);
    }
}
