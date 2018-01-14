using DesktopApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.controllers
{
    class SupplierController
    {
        static HttpClient client = HttpBuilder.Build();
        public static async Task<HttpResponseMessage> CreateProductAsync(Supplier supplier)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "Supplier", supplier);

            return response;
        }

        public static async Task<Supplier> GetProductAsync(string path)
        {
            Supplier supplier = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                supplier = await response.Content.ReadAsAsync<Supplier>();
            }
            return supplier;
        }

        public static async Task<Supplier> UpdateProductAsync(Supplier supplier)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"Supplier/{supplier.Id}", supplier);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            supplier = await response.Content.ReadAsAsync<Supplier>();
            return supplier;
        }

        public static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"Supplier/{id}");
            return response.StatusCode;
        }

        public static async Task<IEnumerable<Supplier>> GetAllSupplierAsync()
        {
            HttpResponseMessage response = await client.GetAsync("Supplier");
            var supplier = await response.Content.ReadAsAsync<IEnumerable<Supplier>>();
            return supplier;
        }
    }
}
