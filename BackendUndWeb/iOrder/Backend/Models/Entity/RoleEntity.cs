﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class RoleEntity
    {
        public virtual long Id { get; set; }
        public virtual string RoleName { get; set; }
    }
}
