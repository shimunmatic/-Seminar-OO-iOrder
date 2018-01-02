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
        private IProductRepository ProductRepository;
        private BaseRepository<OrderEntity> BaseRepository;

        public OrderRepository(IProductRepository productRepository, IConverter<Order, OrderEntity> modelEntity, IConverter<OrderEntity, Order> entityModel, IConverter<OrderPairEntity, OrderPair> orderPairConverter)
        {
            ModelEntity = modelEntity;
            EntityModel = entityModel;
            OrderPairEntityModel = orderPairConverter;
            ProductRepository = productRepository;
            BaseRepository = new BaseRepository<OrderEntity>();
        }

        public bool Delete(Order t)
        {
            return BaseRepository.Delete(ModelEntity.Convert(t));
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = EntityModel.Convert(BaseRepository.GetAll());
            foreach (var o in orders)
            {
                o.OrderedProducts = GetOrderPairs(o);
            }
            return orders;
        }

        private IEnumerable<OrderPair> GetOrderPairs(Order o)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var est = db.Query<EstablishmentEntity>().Where(e => e.Id == o.EstablishmentId).First();
                var entityPairs = db.Query<OrderPairEntity>().Where(op => op.OrderId == o.Id).ToList();
                var orderPairs = new List<OrderPair>();
                foreach (var item in entityPairs)
                {
                    var op = OrderPairEntityModel.Convert(item);
                    op.Product = ProductRepository.GetProductsForWarehouse(est.WarehouseId).Where(p => p.Id == item.ProductId).First();
                    orderPairs.Add(op);
                }
                return orderPairs;

            }
        }

        public Order GetById(object Id)
        {
            var order = EntityModel.Convert(BaseRepository.GetById(Id));
            order.OrderedProducts = GetOrderPairs(order);
            return order;
        }

        public IEnumerable<Order> GetOrdersForCustomer(string Username)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var orders = EntityModel.Convert(db.Query<OrderEntity>().Where(o => o.CustomerId.Equals(Username)).ToList());
                foreach (var o in orders)
                {
                    o.OrderedProducts = GetOrderPairs(o);
                }
                return orders;
            }
        }

        public IEnumerable<Order> GetOrdersForEmployee(string Username)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var orders = EntityModel.Convert(db.Query<OrderEntity>().Where(o => o.EmployeeId.Equals(Username)).ToList());
                foreach (var o in orders)
                {
                    o.OrderedProducts = GetOrderPairs(o);
                }
                return orders;
            }
        }

        public IEnumerable<Order> GetOrdersForEstablishment(long Id)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var orders = EntityModel.Convert(db.Query<OrderEntity>().Where(o => o.EstablishmentId == Id).ToList());
                foreach (var o in orders)
                {
                    o.OrderedProducts = GetOrderPairs(o);
                }
                return orders;
            }
        }

        public IEnumerable<Order> GetOrdersForLocation(long Id)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var orders = EntityModel.Convert(db.Query<OrderEntity>().Where(o => o.LocationId == Id).ToList());
                foreach (var o in orders)
                {
                    o.OrderedProducts = GetOrderPairs(o);
                }
                return orders;
            }
        }

        public Order Save(Order t)
        {
            var o = EntityModel.Convert(BaseRepository.Save(ModelEntity.Convert(t)));
            o.OrderedProducts = t.OrderedProducts;
            return o;
        }

        public Order Update(object Id, Order t)
        {
            var o = EntityModel.Convert(BaseRepository.Update(Id, ModelEntity.Convert(t)));
            o.OrderedProducts = t.OrderedProducts;
            return o;
        }
    }
}
