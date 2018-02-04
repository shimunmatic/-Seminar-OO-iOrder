using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Interface
{
    public interface ICategoryService : IBaseService<Category>
    {
        //IEnumerable<Category> GetAllForEstablishment(long id);
        IEnumerable<Category> GetAllForWarehouseId(long id);
        IEnumerable<Category> GetAllForOwner(string username);
    }
}
