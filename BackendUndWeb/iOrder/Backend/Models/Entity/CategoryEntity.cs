using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class CategoryEntity
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }


    }
}
