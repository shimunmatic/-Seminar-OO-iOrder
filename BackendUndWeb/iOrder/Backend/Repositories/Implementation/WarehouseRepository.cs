using Backend.Converters;
using Backend.Models.Business;
using Backend.Models.Entity;
using Backend.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repositories.Implementation
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private IConverter<Warehouse, WarehouseEntity> ModelEntity;
        private IConverter<WarehouseEntity, Warehouse> EntityModel;
        private BaseRepository<WarehouseEntity> BaseRepository;

        public WarehouseRepository(IConverter<Warehouse, WarehouseEntity> modelEntity, IConverter<WarehouseEntity, Warehouse> entityModel)
        {
            ModelEntity = modelEntity;
            EntityModel = entityModel;
            BaseRepository = new BaseRepository<WarehouseEntity>();
        }

        public void AddProductQuantityToWarehouse(long id, long warehouseId, int quantity)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                using (var transaction = db.BeginTransaction())
                {
                    var wp = db.Query<WarehouseProductEntity>().Where(wpe => wpe.ProductId == id && wpe.WearhouseId == warehouseId).First();
                    if (null != wp)
                    {
                        wp.Quantity += quantity;
                        db.SaveOrUpdate(wp);
                        transaction.Commit();
                    }
                }
            }
        }

        public void AddProductToWarehouse(WarehouseProductEntity entity)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                using (var transaction = db.BeginTransaction())
                {
                    var wp = db.Query<WarehouseProductEntity>().Where(wpe => wpe.ProductId == entity.ProductId && wpe.WearhouseId == entity.WearhouseId).First();
                    if (null == wp)
                        db.Save(entity);
                    else
                    {
                        wp.SellingPrice = entity.SellingPrice;
                        wp.Quantity += entity.Quantity;
                        db.SaveOrUpdate(wp);
                    }
                    transaction.Commit();
                }
            }
        }

        public bool Delete(Warehouse t) => BaseRepository.Delete(ModelEntity.Convert(t));
        public IEnumerable<Warehouse> GetAll() => EntityModel.Convert(BaseRepository.GetAll());

        public Warehouse GetById(object Id) => EntityModel.Convert(BaseRepository.GetById(Id));

        public int GetQuantityForProductInWarehouse(long productId, long warehouseId)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var wp = db.Query<WarehouseProductEntity>().Where(wpe => wpe.ProductId == productId && wpe.WearhouseId == warehouseId).First();
                if (null == wp)
                    return -1;
                else
                    return wp.Quantity;
            }
        }

        public IEnumerable<Warehouse> GetWearhousesForOwner(string Username)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                return EntityModel.Convert(db.Query<WarehouseEntity>().Where(w => w.OwnerId.Equals(Username)));
            }
        }

        public void ReduceProductQuantityFromWarehouse(long productId, long warehouseId, int quantity)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                using (var transaction = db.BeginTransaction())
                {
                    var wp = db.Query<WarehouseProductEntity>().Where(wpe => wpe.ProductId == productId && wpe.WearhouseId == warehouseId).First();
                    if (null != wp)
                    {
                        wp.Quantity -= quantity;
                        db.SaveOrUpdate(wp);
                        transaction.Commit();
                    }
                }
            }
        }

        public object Save(Warehouse t) => (long)BaseRepository.Save(ModelEntity.Convert(t));

        public object Update(object Id, Warehouse t) => (long)BaseRepository.Update(Id, ModelEntity.Convert(t));
    }
}
