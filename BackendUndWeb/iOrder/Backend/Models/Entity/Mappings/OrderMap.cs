using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Backend.Models.Entity.Mappings
{
    public class OrderMap : ClassMap<OrderEntity>
    {
        public OrderMap()
        {
            Table("[order]");
            Schema("dbo");
            Id(o => o.Id).Column("id").GeneratedBy.Native();
            Map(o => o.Date).Column("date");
            Map(o => o.Paid).Column("paid");
            Map(o => o.EstablishmentId).Column("establishment_id");
            Map(o => o.CustomerId).Column("customer_id");
            Map(o => o.EmployeeId).Column("employee_id");
            Map(o => o.LocationId).Column("location_id");
        }
    }
}
