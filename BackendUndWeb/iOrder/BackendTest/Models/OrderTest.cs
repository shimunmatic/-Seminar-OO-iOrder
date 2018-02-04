using System;
using System.Collections.Generic;
using Backend.Models.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackendTest.Models
{
    [TestClass]
    public class OrderTest
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
        public void TestTotalPriceOfOrder()
        {
            Assert.AreEqual((decimal)315.0, order.Price);
        }
    }
}
