using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Backend.Models.Entity.Mappings
{
    public class OrderPairMap : ClassMap<OrderPairEntity>
    {
        public OrderPairMap()
        {
            Table("order_pair");
            Schema("dbo");
            Id(op => op.Id).Column("id").GeneratedBy.Native();
            Map(op => op.Quantity).Column("quantity");
          //  Map(op => op.OrderId).Column("order_id");
            References(op => op.Order).Column("order_id").Not.LazyLoad();
            Map(op => op.ProductId).Column("product_id");
            References(op => op.Product).Column("product_id").Not.LazyLoad().ReadOnly();
        }
    }
}
