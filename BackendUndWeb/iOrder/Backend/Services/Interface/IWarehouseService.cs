using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Interface
{
    public interface IWarehouseService
    {
        Warehouse GetWarehouse(long id);
    }
}
