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

        public User Get(string Username)
        {
            return UserRepository.GetById(Username);
        }

        public IEnumerable<User> GetAllEmployeesForEstablishment(long Id)
        {
            return UserRepository.GetEmployeesOfEsatblishemnt(Id);
        }

        public IEnumerable<User> GetAllEmployeesForOwner(string Username)
        {
            return UserRepository.GetEmployeesOfOwner(Username);
        }

        public User Register(User user)
        {
            user.Role = RoleRepository.GetByName("CUSTOMER");
            user.EstablishmentId = 2;
            return UserRepository.GetById(UserRepository.Sadve(user));
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
