using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class EstablishmentEntity
    {

        public virtual long Id { get; set; }
        public virtual long WarehouseId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string OwnerId { get; set; }
        public virtual string Zip { get; set; }
        public virtual string City { get; set; }

    }
}
