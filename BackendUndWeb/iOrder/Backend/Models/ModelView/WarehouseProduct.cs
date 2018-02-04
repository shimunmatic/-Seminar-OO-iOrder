using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.ModelView
{
    public class WarehouseProduct
    {
        public virtual long ProductId { get; set; }
        public virtual long WarehouseId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal SellingPrice { get; set; }

    }
}
