using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.models
{
    class Product: ItemInterface
    {
        public virtual long Id { get; set; }
        public virtual long CategoryId { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal BuyingPrice { get; set; }
        public virtual string OwnerId { get; set; }
        public virtual long SupplierId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
