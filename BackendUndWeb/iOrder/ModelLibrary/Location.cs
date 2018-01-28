using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Business
{
    public class Location
    {
        public virtual long Id { get; set; }
        public virtual long EstablishmentId { get; set; }
        public virtual string Name { get; set; }
    }
}
