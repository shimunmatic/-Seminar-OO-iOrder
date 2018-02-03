using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Converters.EntityBusiness;
using Backend.Models.Business;
using Backend.Models.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackendTest.Converters
{
    [TestClass]
    public class OrderModelToEntityConverterTest
    {
        private Order order;

        [TestInitialize]
        public void Setup()
        {

            OrderPair op1 = new OrderPair
            {
                OrderId = 1,
                Product = new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    BuyingPrice = 10,
                    Name = "Pan",
                    OwnerId = "fukic",
                    SellingPrice = 15,
                    SupplierId = 1
                },
                Quantity = 4

            };

            OrderPair op2 = new OrderPair
            {
                OrderId = 1,
                Product = new Product
                {
                    Id = 2,
                    CategoryId = 3,
                    BuyingPrice = 2,
                    Name = "Kava duga",
                    OwnerId = "fukic",
                    SellingPrice = 15,
                    SupplierId = 1
                },
                Quantity = 7

            };
            OrderPair op3 = new OrderPair
            {
                OrderId = 1,
                Product = new Product
                {
                    Id = 3,
                    CategoryId = 2,
                    BuyingPrice = 16,
                    Name = "Whiskey",
                    OwnerId = "fukic",
                    SellingPrice = 30,
                    SupplierId = 1
                },
                Quantity = 5
            };

            var OrderedProducts = new List<OrderPair>();
            OrderedProducts.Add(op1);
            OrderedProducts.Add(op2);
            OrderedProducts.Add(op3);

            order = new Order
            {
                EstablishmentId = 1,
                CustomerId = "mimy",
                Date = DateTime.Now,
                LocationId = 1,
                OrderedProducts = OrderedProducts
            };
        }

        [TestMethod]
        public void TestConvert()
        {
            var converter = new OrderModelToEntityConverter(new OrderPairModelToEntityConverter());
            var orderEntity = converter.Convert(order);

            Assert.IsInstanceOfType(orderEntity, new OrderEntity().GetType());
            Assert.AreEqual(order.EstablishmentId, orderEntity.EstablishmentId);
            Assert.AreEqual(order.CustomerId, orderEntity.CustomerId);
            Assert.AreEqual(order.Date, orderEntity.Date);
            Assert.AreEqual(order.LocationId, orderEntity.LocationId);

            Assert.AreEqual(order.OrderedProducts.Count(), orderEntity.OrderPairs.Count());

            Assert.IsInstanceOfType(orderEntity.OrderPairs.First(), new OrderPairEntity().GetType());

            Assert.AreEqual(1, orderEntity.OrderPairs.ElementAt(0).ProductId);

        }
    }
}
