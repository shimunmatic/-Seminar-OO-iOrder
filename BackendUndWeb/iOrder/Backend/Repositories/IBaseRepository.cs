using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);
        object Save(T t);
        object Update(object Id, T t);
        bool Delete(T t);
    }
}
