using Backend.Converters;
using Backend.Converters.EntityBusiness;
using Backend.Models.Business;
using Backend.Models.Entity;
using Backend.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private IConverter<Order, OrderEntity> ModelEntity;
        private IConverter<OrderEntity, Order> EntityModel;
        private IConverter<OrderPairEntity, OrderPair> OrderPairEntityModel;
        private IConverter<OrderPair, OrderPairEntity> OrderPairModelEntity;

        private IProductRepository ProductRepository;
        private BaseRepository<OrderEntity> BaseRepository;

        public OrderRepository(IConverter<Order, OrderEntity> modelEntity, IConverter<OrderEntity, Order> entityModel, IConverter<OrderPairEntity, OrderPair> orderPairEntityModel, IConverter<OrderPair, OrderPairEntity> orderPairModelEntity, IProductRepository productRepository)
        {
            ModelEntity = modelEntity;
            EntityModel = entityModel;
            OrderPairEntityModel = orderPairEntityModel;
            OrderPairModelEntity = orderPairModelEntity;
            ProductRepository = productRepository;
            BaseRepository = new BaseRepository<OrderEntity>();
        }

        public bool Delete(Order t)
        {
            return BaseRepository.Delete(ModelEntity.Convert(t));
        }

        public IEnumerable<Order> GetAll()
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var entites = BaseRepository.GetAll();
                var warehouseProducts = db.Query<WarehouseProductEntity>().ToList();
                var est = db.Query<EstablishmentEntity>().ToList();
                var orders = EntityModel.Convert(entites);
                foreach (var o in orders)
                {
                    foreach (var op in o.OrderedProducts)
                    {

                        op.Product.SellingPrice = warehouseProducts.Where(w => w.WearhouseId == est.Where(e => e.Id == o.EstablishmentId).First().WarehouseId && w.ProductId == op.Product.Id).FirstOrDefault().SellingPrice;
                    }
                }
                return orders;
            }
        }

        private IEnumerable<OrderPair> GetOrderPairs(Order o)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var est = db.Query<EstablishmentEntity>().Where(e => e.Id == o.EstablishmentId).First();
                var entityPairs = db.Query<OrderPairEntity>().Where(op => op.OrderId == o.Id).ToList();
                var warehouseProducts = ProductRepository.GetProductsForWarehouse(est.WarehouseId);
                var orderPairs = new List<OrderPair>();
                foreach (var item in entityPairs)
                {
                    var op = OrderPairEntityModel.Convert(item);
                    op.Product = warehouseProducts.Where(w => w.Id == item.ProductId).First();
                    orderPairs.Add(op);
                }
                return orderPairs;

            }
        }

        public Order GetById(object Id)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var entites = BaseRepository.GetById(Id);
                var warehouseProducts = db.Query<WarehouseProductEntity>().ToList();
                var est = db.Query<EstablishmentEntity>().ToList();
                var order = EntityModel.Convert(entites);

                foreach (var op in order.OrderedProducts)
                {

                    op.Product.SellingPrice = warehouseProducts.Where(w => w.WearhouseId == est.Where(e => e.Id == order.EstablishmentId).First().WarehouseId && w.ProductId == op.Product.Id).FirstOrDefault().SellingPrice;
                }

                return order;
            }
        }

        public IEnumerable<Order> GetOrdersForCustomer(string Username)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var entites = db.Query<OrderEntity>().Where(o => o.CustomerId.Equals(Username)).ToList();
                var warehouseProducts = db.Query<WarehouseProductEntity>().ToList();
                var est = db.Query<EstablishmentEntity>().ToList();
                var orders = EntityModel.Convert(entites);
                foreach (var o in orders)
                {
                    foreach (var op in o.OrderedProducts)
                    {

                        op.Product.SellingPrice = warehouseProducts.Where(w => w.WearhouseId == est.Where(e => e.Id == o.EstablishmentId).First().WarehouseId && w.ProductId == op.Product.Id).FirstOrDefault().SellingPrice;
                    }
                }
                return orders;
            }
        }

        public IEnumerable<Order> GetOrdersForEmployee(string Username)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var entites = db.Query<OrderEntity>().Where(o => o.EmployeeId.Equals(Username)).ToList();
                var warehouseProducts = db.Query<WarehouseProductEntity>().ToList();
                var est = db.Query<EstablishmentEntity>().ToList();
                var orders = EntityModel.Convert(entites);
                foreach (var o in orders)
                {
                    foreach (var op in o.OrderedProducts)
                    {

                        op.Product.SellingPrice = warehouseProducts.Where(w => w.WearhouseId == est.Where(e => e.Id == o.EstablishmentId).First().WarehouseId && w.ProductId == op.Product.Id).FirstOrDefault().SellingPrice;
                    }
                }
                return orders;
            }
        }

        public IEnumerable<Order> GetOrdersForEstablishment(long Id)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var entites = db.Query<OrderEntity>().Where(o => o.EstablishmentId == Id).ToList();
                var warehouseProducts = db.Query<WarehouseProductEntity>().ToList();
                var est = db.Query<EstablishmentEntity>().ToList();
                var orders = EntityModel.Convert(entites);
                foreach (var o in orders)
                {
                    foreach (var op in o.OrderedProducts)
                    {

                        op.Product.SellingPrice = warehouseProducts.Where(w => w.WearhouseId == est.Where(e => e.Id == o.EstablishmentId).First().WarehouseId && w.ProductId == op.Product.Id).FirstOrDefault().SellingPrice;
                    }
                }
                return orders;
            }
        }

        public IEnumerable<Order> GetOrdersForLocation(long Id)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var entites = db.Query<OrderEntity>().Where(o => o.LocationId == Id).ToList();
                var warehouseProducts = db.Query<WarehouseProductEntity>().ToList();
                var est = db.Query<EstablishmentEntity>().ToList();
                var orders = EntityModel.Convert(entites);
                foreach (var o in orders)
                {
                    foreach (var op in o.OrderedProducts)
                    {

                        op.Product.SellingPrice = warehouseProducts.Where(w => w.WearhouseId == est.Where(e => e.Id == o.EstablishmentId).First().WarehouseId && w.ProductId == op.Product.Id).FirstOrDefault().SellingPrice;
                    }
                }
                return orders;
            }
        }

        public object Save(Order t)
        {
            var orderpairs = new List<OrderPair>(t.OrderedProducts);
            t.OrderedProducts = new List<OrderPair>();
            var orderId = (long)BaseRepository.Save(ModelEntity.Convert(t));
            using (var db = NHibernateHelper.OpenSession())
            {
                using (var transaction = db.BeginTransaction())
                {
                    foreach (var op in orderpairs)
                    {
                        op.OrderId = orderId;
                        db.Save(OrderPairModelEntity.Convert(op));
                    }
                    transaction.Commit();
                    return orderId;
                }
            }


        }

        public object Update(object Id, Order t)
        {
            return (long)BaseRepository.Update(Id, ModelEntity.Convert(t));

        }
    }
}
