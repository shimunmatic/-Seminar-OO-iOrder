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
    public class EstablishmentServiceTest
    {
        private Mock<IEstablishmentRepository> estRepo;
        private Mock<ICategoryService> catSer;
        private Mock<ILocationService> locSer;

        [TestInitialize]
        public void Setup()
        {
            estRepo = new Mock<IEstablishmentRepository>();
            catSer = new Mock<ICategoryService>();
            locSer = new Mock<ILocationService>();

            var est1 = new Establishment
            {
                Id = 1,
                Address = "A",
                City = "B",
                Name = "C",
                OwnerId = "fukic",
                WarehouseId = 1,
                Zip = "ZIP"
            };
            var est2 = new Establishment
            {
                Id = 2,
                Address = "E",
                City = "B",
                Name = "D",
                OwnerId = "fukic2",
                WarehouseId = 2,
                Zip = "ZIP"
            };

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
                OwnerId = "fukic2",
                Name = "Cajevi",
            };

            var cat4 = new Category
            {
                Id = 4,
                OwnerId = "fukic2",
                Name = "Kave",
            };

            var loc1 = new Location
            {
                Id = 1,
                EstablishmentId = 1,
                Name = "Balkon"
            };
            var loc2 = new Location
            {
                Id = 2,
                EstablishmentId = 2,
                Name = "Podrum"
            };

            var locations1 = new List<Location>();
            locations1.Add(loc1);
            var locations2 = new List<Location>();
            locations2.Add(loc2);

            var categories1 = new List<Category>();
            categories1.Add(cat1);
            categories1.Add(cat2);
            var categories2 = new List<Category>();
            categories2.Add(cat4);
            categories2.Add(cat3);

            locSer.Setup(x => x.GetLocationsForEstablishmentId(1)).Returns(locations1);
            locSer.Setup(x => x.GetLocationsForEstablishmentId(2)).Returns(locations2);

            catSer.Setup(x => x.GetAllForWarehouseId(1)).Returns(categories1);
            catSer.Setup(x => x.GetAllForWarehouseId(2)).Returns(categories2);
            var list = new List<Establishment>();
            list.Add(est1);
            list.Add(est2);

            var list1 = new List<Establishment>();
            list1.Add(est1);
            var list2 = new List<Establishment>();
            list2.Add(est2);

            estRepo.Setup(x => x.GetEstablishmentsForOwner("fukic")).Returns(list1);
            estRepo.Setup(x => x.GetEstablishmentsForOwner("fukic2")).Returns(list2);
            estRepo.Setup(x => x.GetAll()).Returns(list);



        }

        [TestMethod]
        public void TestGetAllEstablishments()
        {
            var service = new EstablishmentService(catSer.Object, locSer.Object, estRepo.Object);
            var estList = service.GetAll();

            Assert.AreEqual(2, estList.Count());

        }

        [TestMethod]
        public void TestGetAllEstablishmentsForOwner()
        {
            var service = new EstablishmentService(catSer.Object, locSer.Object, estRepo.Object);
            var estList = service.GetAllForOwner("fukic");

            Assert.AreEqual(1, estList.Count());
            var locations = estList.First().Locations;
            var categories = estList.First().Categories;

            Assert.AreEqual(1, locations.Count());
            Assert.AreEqual(2, categories.Count());

            var estList2 = service.GetAllForOwner("fukic2");

            Assert.AreEqual(1, estList2.Count());
            var locations2 = estList.First().Locations;
            var categories2 = estList.First().Categories;

            Assert.AreEqual(1, locations2.Count());
            Assert.AreEqual(2, categories2.Count());

        }

        [TestMethod]
        public void TestGetAllEstablishmentsForOwnerWhoHasZeroEst()
        {
            var service = new EstablishmentService(catSer.Object, locSer.Object, estRepo.Object);
            var estList = service.GetAllForOwner("fukicc");

            Assert.AreEqual(0, estList.Count());
        }

    }
}
