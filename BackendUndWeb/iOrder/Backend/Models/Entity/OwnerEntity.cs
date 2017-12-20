using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class OwnerEntity
    {
        public string Username { get; set; }
        public long RoleId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
    }
}
