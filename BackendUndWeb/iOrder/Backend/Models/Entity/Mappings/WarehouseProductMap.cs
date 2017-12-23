using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHibernate.Linq;

namespace Backend.Models.Entity.Mappings
{
    public class WarehouseProductMap:ClassMap<WarehouseProductEntity>
    {
        public WarehouseProductMap()
        {
            Table("warehouse_product");
            Schema("dbo");
            Id(wp => wp.Id).Column("id").GeneratedBy.Increment();
            Map(wp => wp.ProductId).Column("product_id");
            Map(wp => wp.WearhouseId).Column("warehouse_id");
            Map(wp => wp.SellingPrice).Column("selling_price");
        }
    }
}
