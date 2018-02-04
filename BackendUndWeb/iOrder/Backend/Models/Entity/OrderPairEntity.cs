using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class OrderPairEntity
    {
        public virtual long Id { get; set; }
        public virtual long OrderId { get; set; }
        public virtual OrderEntity Order { get; set; }
        public virtual int Quantity { get; set; }
        public virtual long ProductId { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
