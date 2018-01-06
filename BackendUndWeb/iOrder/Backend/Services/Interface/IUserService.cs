using Backend.Models.Business;
using Backend.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Interface
{
    public interface IUserService
    {
        User Get(string Username, string password);
        User Register(User user);
        bool ValidateUserCredentials(UserCredentials uc);
    }
}
