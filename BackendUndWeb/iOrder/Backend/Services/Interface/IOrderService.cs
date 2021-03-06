﻿using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Interface
{
    public interface IOrderService : IBaseService<Order>
    {

        IEnumerable<Order> GetCustomerHistoryForEstablishmentId(string username, long id);
        IEnumerable<Order> GetHistoryEstablishmentId(long id);
        IEnumerable<Order> GetUnpaidOrdersForEstablishmentId(long id);
        void SetPaid(long id, string employeeId);

    }
}
