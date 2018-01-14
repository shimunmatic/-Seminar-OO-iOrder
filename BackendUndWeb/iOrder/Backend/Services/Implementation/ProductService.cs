using Backend.Models.Business;
using Backend.Models.Entity;
using Backend.Repositories.Interface;
using Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Implementation
{
    public class ProductService : IProductService
    {
        private IProductRepository ProductRepository;
        private IWarehouseRepository WarehouseRepository;

        public ProductService(IProductRepository productRepository, IWarehouseRepository warehouseRepository)
        {
            ProductRepository = productRepository;
            WarehouseRepository = warehouseRepository;
        }

        public void AddProductQuantityToWarehouse(long id, long warehouseId, int quantity)
        {
            WarehouseRepository.AddProductQuantityToWarehouse(id, warehouseId, quantity);
        }

        public void AddProductToWarehouse(long productId, long warehouseId, int quantity, decimal sellingPrice)
        {
            WarehouseRepository.AddProductToWarehouse(new WarehouseProductEntity()
            {
                ProductId = productId,
                WearhouseId = warehouseId,
                Quantity = quantity,
                SellingPrice = sellingPrice
            });
        }

        public void Delete(object id)
        {
            ProductRepository.Delete(ProductRepository.GetById(id));
        }

        public IEnumerable<Product> GetAll()
        {
            return ProductRepository.GetAll();
        }

        public Product GetById(object id)
        {
            return ProductRepository.GetById(id);
        }

        public IEnumerable<Product> GetProductsForCategoryId(long id)
        {
            return ProductRepository.GetProductsForCategory(id);
        }

        public IEnumerable<Product> GetProductsForOwnerId(string username)
        {
            return ProductRepository.GetProductsForOwner(username);
        }

        public IEnumerable<Product> GetProductsForWarehouseId(long id)
        {
            return ProductRepository.GetProductsForWarehouse(id);
        }

        public void ReduceProductQuantityFromWarehouse(long productId, long warehouseId, int quantity)
        {
            WarehouseRepository.ReduceProductQuantityFromWarehouse(productId, warehouseId, quantity);
        }

        public void Save(Product product)
        {
            ProductRepository.Save(product);
        }

        public void Update(object id, Product product)
        {
            ProductRepository.Update(id, product);
        }
    }
}
