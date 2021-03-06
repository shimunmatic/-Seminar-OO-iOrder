﻿using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class OrderEntityToModelConverter : IConverter<OrderEntity, Order>
    {
        IConverter<OrderPairEntity, OrderPair> OrderConverter;

        public OrderEntityToModelConverter(IConverter<OrderPairEntity, OrderPair> orderConverter)
        {
            OrderConverter = orderConverter;
        }

        public Order Convert(OrderEntity Source)
        {
            if (null == Source) return null;
            return new Order
            {
                Id = Source.Id,
                Date = Source.Date,
                EstablishmentId = Source.EstablishmentId,
                CustomerId = Source.CustomerId,
                EmployeeId = Source.EmployeeId,
                Paid = Source.Paid == 1,
                LocationId = Source.LocationId,
                OrderedProducts = OrderConverter.Convert(Source.OrderPairs)
            };
        }

        public IEnumerable<Order> Convert(IEnumerable<OrderEntity> Source)
        {
            if (null == Source) return null;
            var orders = new List<Order>();
            foreach (var o in Source)
            {
                orders.Add(new Order
                {
                    Id = o.Id,
                    Date = o.Date,
                    EstablishmentId = o.EstablishmentId,
                    CustomerId = o.CustomerId,
                    EmployeeId = o.EmployeeId,
                    Paid = o.Paid == 1,
                    LocationId = o.LocationId,
                    OrderedProducts = OrderConverter.Convert(o.OrderPairs)
                });
            }
            return orders;
        }
    }
}
