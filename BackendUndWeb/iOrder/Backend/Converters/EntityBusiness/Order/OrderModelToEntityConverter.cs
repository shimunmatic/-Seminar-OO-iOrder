using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class OrderModelToEntityConverter : IConverter<Order, OrderEntity>
    {
        public OrderEntity Convert(Order Source)
        {
            if (null == Source) return null;
            return new OrderEntity
            {
                Id = Source.Id,
                Date = Source.Date,
                EstablishmentId = Source.EstablishmentId,
                CustomerId = Source.CustomerId,
                EmployeeId = Source.EmployeeId,
                Paid = Source.Paid == true ? (short)1 : (short)0,
                LocationId = Source.LocationId,
            };
        }

        public IEnumerable<OrderEntity> Convert(IEnumerable<Order> Source)
        {
            if (null == Source) return null;
            var orders = new List<OrderEntity>();
            foreach (var o in Source)
            {
                orders.Add(new OrderEntity
                {
                    Id = o.Id,
                    Date = o.Date,
                    EstablishmentId = o.EstablishmentId,
                    CustomerId = o.CustomerId,
                    EmployeeId = o.EmployeeId,
                    Paid = o.Paid == true ? (short)1 : (short)0,
                    LocationId = o.LocationId,
                });
            }
            return orders;
        }
    }
}
