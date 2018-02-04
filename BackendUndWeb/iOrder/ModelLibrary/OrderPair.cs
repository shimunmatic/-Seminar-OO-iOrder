using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Business
{
    public class OrderPair
    {
        public virtual long Id { get; set; }
        public virtual long OrderId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual decimal Price
        {
            get
            {
                return Product.SellingPrice * Quantity;
            }
        }

    }
}
