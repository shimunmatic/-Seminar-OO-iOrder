using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.controllers
{
    class WarehouseController
    {
        static HttpClient client = HttpBuilder.Build();
        public static async Task<Uri> CreateWarehouseAsync(Warehouse warehouse)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "Warehouse", warehouse);
           
            return response.Headers.Location;
        }

        public static async Task<Warehouse> GetWarehouseAsync(string path)
        {
            Warehouse warehouse = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                warehouse = await response.Content.ReadAsAsync<Warehouse>();
            }
            return warehouse;
        }

        public static async Task<Warehouse> UpdateWarehouseAsync(Warehouse warehouse)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"Warehouse/{warehouse.Id}", warehouse);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            warehouse = await response.Content.ReadAsAsync<Warehouse>();
            return warehouse;
        }
        public static async Task<HttpStatusCode> DeleteWarehouseAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"Warehouse/{id}");
            return response.StatusCode;
        }

        public static async Task<IEnumerable<Warehouse>> GetAllWarehouseAsync()
        {
            HttpResponseMessage response = await client.GetAsync("Warehouse");
            var warehouse = await response.Content.ReadAsAsync<IEnumerable<Warehouse>>();
            return warehouse;
        }

    }
}

