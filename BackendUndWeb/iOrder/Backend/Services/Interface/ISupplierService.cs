using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Interface
{
    public interface ISupplierService : IBaseService<Supplier>
    {
        IEnumerable<Supplier> GetSuppliersForOwner(string username);
        void NotifySupplier(long id, string message);
    }
}
