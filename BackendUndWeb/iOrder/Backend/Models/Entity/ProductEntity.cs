using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class ProductEntity
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public decimal BuyingPrice { get; set; }
        public string OwnerId { get; set; }
        public string SupplierId { get; set; }
    }
}
