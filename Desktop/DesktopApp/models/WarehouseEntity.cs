using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    class WarehouseEntity
    {
        public virtual long Id { get; set; }
        public virtual string OwnerId { get; set; }
        public virtual string Address { get; set; }
        public virtual string Zip { get; set; }
        public virtual string City { get; set; }
    }
}
