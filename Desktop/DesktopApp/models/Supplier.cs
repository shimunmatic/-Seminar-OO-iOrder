using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.models
{
    class Supplier
    {

        public virtual long Id { get; set; }
        public virtual string OwnerId { get; set; }
        public virtual string Email { get; set; }
        public virtual string Name { get; set; }
        public virtual string PhoneNumber { get; set; }
    }
}
