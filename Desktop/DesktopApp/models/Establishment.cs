using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.models
{
    class Establishment: ItemInterface
    {

        public virtual long Id { get; set; }
        public virtual long WarehouseId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string OwnerId { get; set; }
        public virtual string Zip { get; set; }
        public virtual string City { get; set; }


        public override string ToString()
        {
            return Name;
        }

		//public async static long findEstablishment(string name, IEnumerable<Establishment> list)
		//{
		//	IEnumerable<Establishment> lista = await MainController.GetAllItemsAsync<Establishment>("Establishment");
		//	return list.First(c => c.Name == name).Id;

		//}
	}
}
