using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Backend.Models.Entity.Mappings
{
    public class SupplierMap : ClassMap<SupplierEntity>
    {
        public SupplierMap()
        {
            Table("supplier");
            Schema("dbo");
            Id(s => s.Id).Column("id").GeneratedBy.Increment();
            Map(s => s.OwnerId).Column("owner_id");
            Map(s => s.Email).Column("email");
            Map(s => s.Name).Column("name");
            Map(s => s.PhoneNumber).Column("phone_number");
        }
    }
}
