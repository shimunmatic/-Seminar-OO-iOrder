using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Backend.Models.Entity.Mappings
{
    public class OwnerMap : ClassMap<OwnerEntity>
    {
        public OwnerMap()
        {
            Table("owner");
            Schema("dbo");
            Id(o => o.Username).Column("username").GeneratedBy.Assigned();
            Map(o => o.Password).Column("password");
            Map(o => o.Zip).Column("zip");
            Map(o => o.Address).Column("address");
            Map(o => o.City).Column("city");
            Map(o => o.Email).Column("email");
            Map(o => o.PhoneNumber).Column("phone_number");
            Map(o => o.RoleId).Column("role_id");
        }
    }
}
