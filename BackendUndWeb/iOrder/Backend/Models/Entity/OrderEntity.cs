using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class OrderEntity
    {
        public virtual long Id { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string EmployeeId { get; set; }
        public virtual short Paid { get; set; }
        public virtual long LocationId { get; set; }
        public virtual long EstablishmentId { get; set; }
        public virtual IEnumerable<OrderPairEntity> OrderPairs { get; set; }

        public OrderEntity()
        {
            OrderPairs = new List<OrderPairEntity>();
        }


    }
}
