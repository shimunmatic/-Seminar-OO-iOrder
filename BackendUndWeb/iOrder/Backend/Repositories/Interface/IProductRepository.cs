﻿using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.Interface
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IEnumerable<Product> GetProductsForWarehouse(long Id);
        IEnumerable<Product> GetProductsForCategory(long Id);
        IEnumerable<Product> GetProductsForOwner(string Username);
        IEnumerable<Product> GetProductsForSupplier(long Id);




    }
}
