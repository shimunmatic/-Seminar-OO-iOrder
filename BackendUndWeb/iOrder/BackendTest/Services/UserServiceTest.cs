using System;
using Backend.Models.Business;
using Backend.Models.ModelView;
using Backend.Repositories.Interface;
using Backend.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BackendTest.Services
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void TestUserCredentialsCorrect()
        {
            var userRepo = new Mock<IUserRepository>();
            var user = new User
            {
                Username = "mimy",
                Email = "mimy@email.com",
                Password = "mimica123",
                FirstName = "Martin",
                LastName = "Mihalic",
                Role = new Role
                {
                    Id = 1,
                    RoleName = "CUSTOMER"
                }
            };
            userRepo.Setup(x => x.GetById("mimy")).Returns(user);
            var service = new UserService(userRepo.Object, null);
            var flag = service.ValidateUserCredentials(new UserCredentials
            {
                Username = "mimy",
                Password = "mimica123"
            });
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void TestUserCredentialsWrongPassword()
        {
            var userRepo = new Mock<IUserRepository>();
            var user = new User
            {
                Username = "mimy",
                Email = "mimy@email.com",
                Password = "mimica123",
                FirstName = "Martin",
                LastName = "Mihalic",
                Role = new Role
                {
                    Id = 1,
                    RoleName = "CUSTOMER"
                }
            };
            userRepo.Setup(x => x.GetById("mimy")).Returns(user);
            var service = new UserService(userRepo.Object, null);
            var flag = service.ValidateUserCredentials(new UserCredentials
            {
                Username = "mimy",
                Password = "mimica1234"
            });
            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void TestUserCredentialsNoSuchUser()
        {
            var userRepo = new Mock<IUserRepository>();

            userRepo.Setup(x => x.GetById("fakeuser")).Returns(() => null);
            var service = new UserService(userRepo.Object, null);
            var flag = service.ValidateUserCredentials(new UserCredentials
            {
                Username = "fakeuser",
                Password = "fakeuserPass"
            });
            Assert.IsFalse(flag);
        }
    }
}
