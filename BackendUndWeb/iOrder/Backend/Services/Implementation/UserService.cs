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

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
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
            return UserRepository.Save(user);
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
