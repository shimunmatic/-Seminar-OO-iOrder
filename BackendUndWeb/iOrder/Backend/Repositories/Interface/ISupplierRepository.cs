﻿using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.Interface
{
    interface ISupplierRepository:IBaseRepository<Supplier>
    {
        IEnumerable<Supplier> GetSuppliersForOwner(string username);
    }
}
