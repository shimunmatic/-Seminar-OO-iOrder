using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class OrderPairModelToEntityConverter : IConverter<OrderPair, OrderPairEntity>
    {

        public OrderPairEntity Convert(OrderPair Source)
        {
            if (null == Source) return null;
            return new OrderPairEntity
            {
                Id = Source.Id,
                OrderId = Source.OrderId,
                Quantity = Source.Quantity,
                ProductId = Source.Product.Id,

            };
        }

        public IEnumerable<OrderPairEntity> Convert(IEnumerable<OrderPair> Source)
        {
            if (null == Source) return null;
            var orderPairs = new List<OrderPairEntity>();
            foreach (var o in Source)
            {
                orderPairs.Add(new OrderPairEntity
                {
                    Id = o.Id,
                    OrderId = o.OrderId,
                    Quantity = o.Quantity,
                    ProductId = o.Product.Id,

                });
            }
            return orderPairs;
        }
    }
}
