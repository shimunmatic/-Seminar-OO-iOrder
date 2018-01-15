using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    class HttpBuilder
    {
        private static HttpClient client;
            
        public static void Init()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("http://iorder.azurewebsites.net/api/")
               
            };
        }

        public static HttpClient Build() {
            return client;
        }
        public static void AddHeader(string token)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
       
    }
}
