using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Interface
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsForWarehouseId(long id);
        IEnumerable<Product> GetProductsForCategoryId(long id);
        IEnumerable<Product> GetProductsForOwnerId(string username);
        void Save(Product product);

    }
}
