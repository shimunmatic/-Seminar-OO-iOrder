using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class WarehouseProductEntity
    {
        public virtual long Id { get; set; }
        public virtual long ProductId { get; set; }
        public virtual long WearhouseId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal SellingPrice { get; set; }
    }
}
