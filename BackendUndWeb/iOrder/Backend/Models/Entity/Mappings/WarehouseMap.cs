using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Backend.Models.Entity.Mappings
{
    public class WarehouseMap:ClassMap<WarehouseEntity>
    {
        public WarehouseMap()
        {
            Table("warehouse");
            Schema("dbo");
            Id(e => e.Id).Column("id").GeneratedBy.Native();
            Map(e => e.Address).Column("address");
            Map(e => e.City).Column("city");
            Map(e => e.Zip).Column("zip");
            Map(e => e.OwnerId).Column("owner_id");
        }
    }
}
