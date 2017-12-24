using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class CategoryEntity
    {
        public virtual long Id { get; set; }
        public virtual long ParentId { get; set; }
        public virtual string Name { get; set; }
        public virtual string OwnerId { get; set; }


    }
}
