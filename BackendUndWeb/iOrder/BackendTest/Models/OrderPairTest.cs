using System;
using Backend.Models.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackendTest.Models
{
    [TestClass]
    public class OrderPairTest
    {
        private OrderPair op1;
        [TestInitialize]
        public void Setup()
        {
            op1 = new OrderPair
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
        }
        [TestMethod]
        public void TestTotalPriceForOrderPair()
        {
            Assert.AreEqual((decimal)60, op1.Price);
        }
    }
}
