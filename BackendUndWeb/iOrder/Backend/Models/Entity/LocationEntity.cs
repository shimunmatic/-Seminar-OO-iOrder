using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class LocationEntity
    {
        public virtual long Id { get; set; }
        public virtual long EstablishmentId { get; set; }
        public virtual string Name { get; set; }

    }
}
