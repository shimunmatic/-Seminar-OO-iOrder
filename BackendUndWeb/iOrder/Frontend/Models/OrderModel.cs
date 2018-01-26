using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class OrderModel
    {

        public virtual long Id { get; set; }
        public virtual User Customer { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual String Employee { get; set; }
        public virtual bool Paid { get; set; }
        public virtual Location Location { get; set; }
        public virtual Establishment Establishment { get; set; }
        public IEnumerable<OrderPair> OrderedProducts { get; set; }
        public decimal Price { get; set; }
    }
}
