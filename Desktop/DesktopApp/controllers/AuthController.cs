using DesktopApp.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.controllers
{
    class AuthController
    {
        static HttpClient client = HttpBuilder.Build();
        public static async Task<HttpResponseMessage> SendAuthInfoAsync(UserCredentials userCredentials)
        {
           
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "Auth", userCredentials);
      
            return response;
        }
    }
}
