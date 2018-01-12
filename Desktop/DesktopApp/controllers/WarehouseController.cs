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

      
        static async Task<Uri> CreateWarehouseAsync(WarehouseEntity warehouse, HttpClient client)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/warehouses", warehouse);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<WarehouseEntity> GetWarehouseAsync(string path, HttpClient client)
        {
            WarehouseEntity warehouse = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                warehouse = await response.Content.ReadAsAsync<WarehouseEntity>();
            }
            return warehouse;
        }

        static async Task<WarehouseEntity> UpdateWarehouseAsync(WarehouseEntity warehouse, HttpClient client)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/warehouses/{warehouse.Id}", warehouse);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            warehouse = await response.Content.ReadAsAsync<WarehouseEntity>();
            return warehouse;
        }

        static async Task<HttpStatusCode> DeleteWarehouseAsync(string id, HttpClient client)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/warehouses/{id}");
            return response.StatusCode;
        }

    }
}

