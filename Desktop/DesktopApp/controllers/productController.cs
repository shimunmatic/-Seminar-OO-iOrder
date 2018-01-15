using DesktopApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.controllers
{
   
    class ProductController
    {
        static HttpClient client = HttpBuilder.Build();
        public static async Task<HttpResponseMessage> CreateProductAsync(ProductEntity product)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "Product", product);

            return response;
        }

        public static async Task<ProductEntity> GetProductAsync(string path)
        {
            ProductEntity product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<ProductEntity>();
            }
            return product;
        }

        public static async Task<ProductEntity> UpdateProductAsync(ProductEntity product)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"Product/{product.Id}", product);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            product = await response.Content.ReadAsAsync<ProductEntity>();
            return product;
        }

        public static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"Product/{id}");
            return response.StatusCode;
        }

        public static async Task<IEnumerable<ProductEntity>> GetAllProductAsync()
        {
            HttpResponseMessage response = await client.GetAsync("Product");
            var product = await response.Content.ReadAsAsync<IEnumerable<ProductEntity>>();

            return product;
        }

    }
}
