using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Backend.Models.Entity.Mappings
{
    public class ProductMap : ClassMap<ProductEntity>
    {
        public ProductMap()
        {
            Table("product");
            Schema("dbo");
            Id(o => o.Id).Column("id").GeneratedBy.Native();
            Map(o => o.CategoryId).Column("category_id");
            Map(o => o.BuyingPrice).Column("buying_price");
            Map(o => o.Name).Column("name");
            Map(o => o.OwnerId).Column("owner_id");
            Map(o => o.SupplierId).Column("supplier_id");
        }
    }
}
