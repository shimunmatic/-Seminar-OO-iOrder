using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Backend.Models.Entity.Mappings
{
    public class CategoryMap : ClassMap<CategoryEntity>
    {
        public CategoryMap()
        {
            Table("category");
            Schema("dbo");
            Id(c => c.Id).Column("id").GeneratedBy.Increment();
            Map(c => c.Name).Column("name");
            Map(c => c.OwnerId).Column("owner_id");
            Map(c => c.OwnerId).Column("parent_category_id");
        }
    }
}
