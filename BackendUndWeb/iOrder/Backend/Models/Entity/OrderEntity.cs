using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class OrderEntity
    {
        public long Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string EmployeeId { get; set; }
        public short Paid { get; set; }
        public long LocationId { get; set; }
        public long EstablishmentId { get; set; }
    }
}
