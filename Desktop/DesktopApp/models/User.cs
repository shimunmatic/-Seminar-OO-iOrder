using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.models
{
	class User: ItemInterface
	{

		public virtual string Username { get; set; }
	
		public virtual string Password { get; set; }
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		public virtual string Email { get; set; }
		


	}

}
