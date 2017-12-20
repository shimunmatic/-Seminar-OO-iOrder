using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class WarehouseProductEntity
    {
        public long ProductId { get; set; }
        public long WearhouseId { get; set; }
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
