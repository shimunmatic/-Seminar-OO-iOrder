using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Business
{
    public class User
    {
        public virtual string Username { get; set; }
        //public virtual Role Role { get; set; }

		public virtual long RoleId { get; set; }
		public virtual string Password { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string OwnerId { get; set; }
        public virtual long? EstablishmentId { get; set; }

    }
}
