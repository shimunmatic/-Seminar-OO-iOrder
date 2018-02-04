using Backend.Converters;
using Backend.Models.Business;
using Backend.Models.Entity;
using Backend.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private IConverter<ProductEntity, Product> EntityModel;
        private IConverter<Product, ProductEntity> ModelEntity;
        private BaseRepository<ProductEntity> BaseRepository;

        public ProductRepository(IConverter<ProductEntity, Product> entityModel, IConverter<Product, ProductEntity> modelEntity)
        {
            EntityModel = entityModel;
            ModelEntity = modelEntity;
            BaseRepository = new BaseRepository<ProductEntity>();
        }

        public bool Delete(Product t) => BaseRepository.Delete(ModelEntity.Convert(t));

        public IEnumerable<Product> GetAll() => EntityModel.Convert(BaseRepository.GetAll());

        public Product GetById(object Id)
        {
            return EntityModel.Convert(BaseRepository.GetById(Id));
        }

        public IEnumerable<Product> GetProductsForCategory(long Id)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                return EntityModel.Convert(db.Query<ProductEntity>().Where(p => p.CategoryId == Id).ToList());
            }
        }

        public IEnumerable<Product> GetProductsForOwner(string Username)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                return EntityModel.Convert(db.Query<ProductEntity>().Where(p => p.OwnerId.Equals(Username)).ToList());
            }
        }

        public IEnumerable<Product> GetProductsForSupplier(long Id)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                return EntityModel.Convert(db.Query<ProductEntity>().Where(p => p.SupplierId.Equals(Id)).ToList());
            }
        }

        public IEnumerable<Product> GetProductsForWarehouse(long Id)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var entities = db.Query<ProductEntity>().ToList();
                var wp = db.Query<WarehouseProductEntity>().Where(w => w.WearhouseId == Id).ToList();
                var products = EntityModel.Convert(from p in entities
                                                   join w in wp
                                                   on p.Id equals w.ProductId
                                                   select p);
                foreach (var p in products)
                {
                    p.SellingPrice = wp.Where(w => w.ProductId == p.Id).First().SellingPrice;
                }
                return products;
            }
        }

        public object Save(Product t) => (long)BaseRepository.Save(ModelEntity.Convert(t));

        public object Update(object Id, Product t) => (long)BaseRepository.Update(Id, ModelEntity.Convert(t));
    }
}
