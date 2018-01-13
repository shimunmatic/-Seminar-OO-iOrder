using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Business
{
    public class Product
    {
        public virtual long Id { get; set; }
        public virtual long CategoryId { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal BuyingPrice { get; set; }
        public virtual string OwnerId { get; set; }
        public virtual long SupplierId { get; set; }
        public virtual decimal SellingPrice { get; set; }

    }
}
