using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.models
{
	class Role
	{
		public virtual long Id { get; set; }
		public virtual string RoleName { get; set; }
		


		public override string ToString()
		{
			return RoleName;
		}
	}

}
