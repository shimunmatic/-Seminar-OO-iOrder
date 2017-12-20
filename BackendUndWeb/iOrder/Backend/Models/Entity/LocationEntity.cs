using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class LocationEntity
    {
        public long Id { get; set; }
        public long EstablishmentId { get; set; }
        public string Name { get; set; }

    }
}
