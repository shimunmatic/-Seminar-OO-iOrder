using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Interface
{
    public interface IProductService : IBaseService<Product>
    {
        IEnumerable<Product> GetProductsForWarehouseId(long id);
        IEnumerable<Product> GetProductsForCategoryId(long id);
        IEnumerable<Product> GetProductsForOwnerId(string username);
        void AddProductToWarehouse(long productId, long warehouseId, int quantity, decimal sellingPrice);
        void ReduceProductQuantityFromWarehouse(long productId, long warehouseId, int quantity);
        void AddProductQuantityToWarehouse(long id, long warehouseId, int quantity);
    }
}
