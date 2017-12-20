using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Entity;

namespace Backend.Models.Business
{
    public class Role
    {
        public virtual long Id { get; set; }
        public virtual string RoleName { get; set; }
        public virtual IEnumerable<UserEntity> Users { get; set; }
    }
}
