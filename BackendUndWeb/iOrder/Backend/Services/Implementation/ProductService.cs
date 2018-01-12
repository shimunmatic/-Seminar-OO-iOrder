using Backend.Models.Business;
using Backend.Repositories.Interface;
using Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Implementation
{
    public class ProductService:IProductService
    {
        private IProductRepository ProductRepository;

        public ProductService(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IEnumerable<Product> GetProductsForCategoryId(long id)
        {
            return ProductRepository.GetProductsForCategory(id);
        }

        public IEnumerable<Product> GetProductsForWarehouseId(long id)
        {
            return ProductRepository.GetProductsForWarehouse(id);
        }
    }
}
