using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.Interface
{
    public interface IOrderRepository:IBaseRepository<Order>
    {
        IEnumerable<Order> GetOrdersForEstablishment(long Id);
        IEnumerable<Order> GetOrdersForCustomer(string Username);
        IEnumerable<Order> GetOrdersForEmployee(string Username);
        IEnumerable<Order> GetOrdersForLocation(long Id);


    }
}
