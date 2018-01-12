using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Business
{
    public class Establishment
    {
        public virtual long Id { get; set; }
        public virtual long WarehouseId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string OwnerId { get; set; }
        public virtual string Zip { get; set; }
        public virtual string City { get; set; }
        public virtual IEnumerable<Category> Categories { get; set; }
        public virtual IEnumerable<Location> Locations { get; set; }


        public Establishment()
        {
            Categories = new List<Category>();
            Locations = new List<Location>();
        }
    }
}
