using Backend.Models.Business;
using Backend.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Interface
{
    public interface IUserService : IBaseService<User>
    {
        bool ValidateUserCredentials(UserCredentials uc);
        IEnumerable<User> GetAllEmployeesForOwner(string Username);
        IEnumerable<User> GetAllEmployeesForEstablishment(long Id);
        void RegisterCustomer(User customer);
        void RegisterEmployee(User employee);
        IEnumerable<User> GetAllAdmins();
        void RegisteAdmin(User user);
    }
}
