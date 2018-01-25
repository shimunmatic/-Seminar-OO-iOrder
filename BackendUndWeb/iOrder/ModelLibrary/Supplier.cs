using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Business
{
    public class Supplier
    {
        public virtual long Id { get; set; }
        public virtual string OwnerId { get; set; }
        public virtual string Email { get; set; }
        public virtual string Name { get; set; }
        public virtual string PhoneNumber { get; set; }
    }
}
