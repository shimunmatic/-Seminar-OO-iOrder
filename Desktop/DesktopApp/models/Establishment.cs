using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.models
{
    class Establishment
    {

        public virtual long Id { get; set; }
        public virtual long WarehouseId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string OwnerId { get; set; }
        public virtual string Zip { get; set; }
        public virtual string City { get; set; }
    }
}
