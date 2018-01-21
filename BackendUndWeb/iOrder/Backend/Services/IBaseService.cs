using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IBaseService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Save(T t);
        void Update(object id, T t);
        void Delete(object id);
    }
}
