using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Business
{
    public class Owner
    {
        public virtual string Username { get; set; }
        public virtual Role Role { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Zip { get; set; }
        public virtual string City { get; set; }


    }
}
