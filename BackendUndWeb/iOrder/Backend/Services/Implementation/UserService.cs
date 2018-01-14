using Backend.Models.Business;
using Backend.Models.ModelView;
using Backend.Repositories.Interface;
using Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository;
        private IRoleRepository RoleRepository;


        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            UserRepository = userRepository;
            RoleRepository = roleRepository;
        }

        public void Delete(object id)
        {
            UserRepository.Delete(UserRepository.GetById(id));
        }

        public IEnumerable<User> GetAll()
        {
            return UserRepository.GetAll();
        }

        public IEnumerable<User> GetAllEmployeesForEstablishment(long Id)
        {
            return UserRepository.GetEmployeesOfEsatblishemnt(Id);
        }

        public IEnumerable<User> GetAllEmployeesForOwner(string Username)
        {
            return UserRepository.GetEmployeesOfOwner(Username);
        }

        public User GetById(object id)
        {
            return UserRepository.GetById(id);
        }

        public void RegisterCustomer(User customer)
        {
            customer.Role = RoleRepository.GetByName("CUSTOMER");
            Save(customer);
        }

        public void RegisterEmployee(User employee)
        {
            employee.Role = RoleRepository.GetByName("EMPLOYEE");
            Save(employee);
        }

        public void Save(User t)
        {
            UserRepository.Save(t);
        }

        public void Update(object id, User t)
        {
            UserRepository.Update(id, t);
        }

        public bool ValidateUserCredentials(UserCredentials uc)
        {
            var u = UserRepository.GetById(uc.Username);
            if (u != null)
                return u.Password.Equals(uc.Password);
            return false;
        }
    }
}
