using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        IEnumerable<User> GetEmployeesOfEsatblishemnt(long Id);
        IEnumerable<User> GetEmployeesOfOwner(string username);

    }
}
