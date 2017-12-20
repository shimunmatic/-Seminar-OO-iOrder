using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Entity
{
    public class EstablishmentEntity
    {

        public long Id { get; set; }
        public long WarehouseId { get; set; }
        public string Address { get; set; }
        public string OwnerId { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }

    }
}
