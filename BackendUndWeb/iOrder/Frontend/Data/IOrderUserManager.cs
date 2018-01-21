using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Data
{

    public class IOrderUserManager
    {
        public static User user { get; set; }

        public static Boolean isLoggedIn { get
            {
                return user != null;
            }
        }


    }


}
