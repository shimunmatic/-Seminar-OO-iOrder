using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Backend.Models.Entity.Mappings
{
    public class EstablishmentMap : ClassMap<EstablishmentEntity>
    {
        public EstablishmentMap()
        {
            Table("establishment");
            Schema("dbo");
            Id(e => e.Id).Column("id").GeneratedBy.Increment();
            Map(e => e.Address).Column("address");
            Map(e => e.Name).Column("name");
            Map(e => e.City).Column("city");
            Map(e => e.Zip).Column("zip");
            Map(e => e.OwnerId).Column("owner_id");
            Map(e => e.WarehouseId).Column("warehouse_id");


        }
    }
}
