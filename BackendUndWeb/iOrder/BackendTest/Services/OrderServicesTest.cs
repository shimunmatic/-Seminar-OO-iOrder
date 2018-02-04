using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Models.Business;
using Backend.Repositories.Interface;
using Backend.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BackendTest.Services
{
    [TestClass]
    public class OrderServicesTest
    {
        [TestMethod]
        public void GetCustomerHistoryForEstablishmentId()
        {
            var OrderRepo = new Mock<IOrderRepository>();
            var Orders = new List<Order>();
            var orderedProducts1 = new List<OrderPair>();
            var orderedProducts2 = new List<OrderPair>();



            var op1 = new OrderPair
            {
                Id = 1,
                OrderId = 1,
                Product = null,
                Quantity = 2
            };

            var op2 = new OrderPair
            {
                Id = 2,
                OrderId = 1,
                Product = null,
                Quantity = 2
            };

            var op3 = new OrderPair
            {
                Id = 2,
                OrderId = 2,
                Product = null,
                Quantity = 2
            };

            orderedProducts1.Add(op1);
            orderedProducts1.Add(op2);

            orderedProducts2.Add(op3);

            Orders.Add(new Order
            {
                Id = 1,
                CustomerId = "mimy",
                Date = DateTime.Now,
                EmployeeId = null,
                EstablishmentId = 1,
                LocationId = 1,
                Paid = false,
                OrderedProducts = orderedProducts1
            });

            Orders.Add(new Order
            {
                Id = 1,
                CustomerId = "mimy",
                Date = DateTime.Now,
                EmployeeId = null,
                EstablishmentId = 2,
                LocationId = 1,
                Paid = false,
                OrderedProducts = orderedProducts2
            });

            OrderRepo.Setup(x => x.GetOrdersForCustomer("mimy")).Returns(Orders);


            var service = new OrderService(OrderRepo.Object, null, null, null, null);

            var userHistory = service.GetCustomerHistoryForEstablishmentId("mimy", 1);
            Assert.AreEqual(1, userHistory.Count());

        }
    }
}
