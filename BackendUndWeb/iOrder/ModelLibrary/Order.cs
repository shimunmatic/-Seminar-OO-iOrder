using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Business
{
    public class Order
    {
        public virtual long Id { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string EmployeeId { get; set; }
        public virtual bool Paid { get; set; }
        public virtual long LocationId { get; set; }
        public virtual long EstablishmentId { get; set; }
        public IEnumerable<OrderPair> OrderedProducts { get; set; }
        public decimal Price
        {
            get
            {
                var price = (decimal)0.0;
                foreach (var op in OrderedProducts)
                {
                    price = price + op.Price;
                }
                return price;
            }
        }

        public Order()
        {
            OrderedProducts = new List<OrderPair>();
        }
    }
}
