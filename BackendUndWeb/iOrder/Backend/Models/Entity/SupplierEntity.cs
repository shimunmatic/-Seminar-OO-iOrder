using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class SupplierEntity
    {
        public virtual long Id { get; set; }
        public virtual long OwnerId { get; set; }
        public virtual string Email { get; set; }
        public virtual string Name { get; set; }
        public virtual string PhoneNumber { get; set; }

    }
}
