﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    class CategoryEntity
    {

        public virtual long Id { get; set; }
        public virtual long ParentId { get; set; }
        public virtual string Name { get; set; }
        public virtual string OwnerId { get; set; }
    }
}