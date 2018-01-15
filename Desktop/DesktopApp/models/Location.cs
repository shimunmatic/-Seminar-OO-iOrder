using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.models
{
    class Location
    {
        public virtual long Id { get; set; }
        public virtual long EstablishmentId { get; set; }
        public virtual string Name { get; set; }
    }
}
