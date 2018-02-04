using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.Interface
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        IEnumerable<Category> GetCategoriesOfOwner(string username);

    }
}
