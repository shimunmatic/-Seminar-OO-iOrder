﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    class Category: ItemInterface
    {

        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string OwnerId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
