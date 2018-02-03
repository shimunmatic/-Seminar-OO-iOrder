using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Models.Business;
using Backend.Repositories.Interface;
using Backend.Services.Implementation;
using Backend.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BackendTest.Services
{
    [TestClass]
    public class CategoryServiceTest
    {
        private Mock<ICategoryRepository> catRepo;
        private Mock<IProductService> prodSer;

        [TestInitialize]
        public void Setup()
        {
            catRepo = new Mock<ICategoryRepository>();
            prodSer = new Mock<IProductService>();
            var cat1 = new Category
            {
                Id = 1,
                OwnerId = "fukic",
                Name = "Rakije",
            };

            var cat2 = new Category
            {
                Id = 2,
                OwnerId = "fukic",
                Name = "Pive",
            };

            var cat3 = new Category
            {
                Id = 3,
                OwnerId = "fukic",
                Name = "Cajevi",
            };

            var cat4 = new Category
            {
                Id = 4,
                OwnerId = "fukic",
                Name = "Kave",
            };

            var pro1 = new Product
            {
                Id = 1,
                CategoryId = 1,
                BuyingPrice = 10,
                Name = "Mrlja",
                OwnerId = "fukic",
                SupplierId = 1,
                SellingPrice = 15
            };

            var pro2 = new Product
            {
                Id = 2,
                CategoryId = 2,
                BuyingPrice = 10,
                Name = "Pan",
                OwnerId = "fukic",
                SupplierId = 1,
                SellingPrice = 15
            };

            var pro3 = new Product
            {
                Id = 3,
                CategoryId = 3,
                BuyingPrice = 10,
                Name = "Vocni",
                OwnerId = "fukic",
                SupplierId = 1,
                SellingPrice = 15
            };

            var pro4 = new Product
            {
                Id = 4,
                CategoryId = 4,
                BuyingPrice = 10,
                Name = "Duga",
                OwnerId = "fukic",
                SupplierId = 1,
                SellingPrice = 15
            };

            var prods = new List<Product>();
            prods.Add(pro1);
            prods.Add(pro2);
            prods.Add(pro3);
            prods.Add(pro4);

            prodSer.Setup(x => x.GetProductsForWarehouseId(1L)).Returns(prods);
            catRepo.Setup(x => x.GetById(1L)).Returns(cat1);
            catRepo.Setup(x => x.GetById(2L)).Returns(cat2);
            catRepo.Setup(x => x.GetById(3L)).Returns(cat3);
            catRepo.Setup(x => x.GetById(4L)).Returns(cat4);


        }

        [TestMethod]
        public void TestGetAllForWarehouseId()
        {
            var service = new CategoryService(catRepo.Object, prodSer.Object);
            var catergories = service.GetAllForWarehouseId(1L);

            Assert.AreEqual(4, catergories.Count());
        }
    }
}
