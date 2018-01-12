using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Backend.Models.Entity.Mappings
{
    public class LocationMap : ClassMap<LocationEntity>
    {
        public LocationMap()
        {
            Table("location");
            Schema("dbo");
            Id(l => l.Id).Column("id").GeneratedBy.Increment();
            Map(l => l.EstablishmentId).Column("establishment_id");
            Map(l => l.Name).Column("name");
        }
    }
}
