using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.models
{
	class WarehouseProduct: ItemInterface
	{

		public virtual long Id { get; set; }
		public virtual long ProductId { get; set; }
		public virtual long WarehouseId { get; set; }
		public virtual int Quantity { get; set; }
		public virtual decimal SellingPrice { get; set; }

		public override string ToString()
		{
			return Id + " " +ProductId + " " + WarehouseId + " " + Quantity + " " + SellingPrice;
		}

	}

	
}
