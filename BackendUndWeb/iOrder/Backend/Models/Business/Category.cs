using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Business
{
    public class Category
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string OwnerId { get; set; }
    }
}
