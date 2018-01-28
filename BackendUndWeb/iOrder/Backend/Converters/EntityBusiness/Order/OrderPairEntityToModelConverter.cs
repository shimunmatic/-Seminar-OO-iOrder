using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class OrderPairEntityToModelConverter : IConverter<OrderPairEntity, OrderPair>
    {
        private IConverter<ProductEntity, Product> ProductConverter;

        public OrderPairEntityToModelConverter(IConverter<ProductEntity, Product> productConverter)
        {
            ProductConverter = productConverter;
        }

        public OrderPair Convert(OrderPairEntity Source)
        {
            if (null == Source) return null;
            return new OrderPair
            {
                Id = Source.Id,
                OrderId = Source.OrderId,
                Quantity = Source.Quantity,
                Product = ProductConverter.Convert(Source.Product)
            };
        }

        public IEnumerable<OrderPair> Convert(IEnumerable<OrderPairEntity> Source)
        {
            if (null == Source) return null;
            var orderPairs = new List<OrderPair>();
            foreach (var o in Source)
            {
                orderPairs.Add(new OrderPair
                {
                    Id = o.Id,
                    OrderId = o.OrderId,
                    Quantity = o.Quantity,
                    Product = ProductConverter.Convert(o.Product)

                });
            }
            return orderPairs;
        }
    }
}
