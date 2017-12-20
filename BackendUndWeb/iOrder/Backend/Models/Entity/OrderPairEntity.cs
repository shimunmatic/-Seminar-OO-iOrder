using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class OrderPairEntity
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public int Quantity { get; set; }
        public long ProductId { get; set; }
    }
}
