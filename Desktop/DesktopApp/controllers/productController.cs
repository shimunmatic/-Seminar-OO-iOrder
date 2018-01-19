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
        public static async Task<HttpResponseMessage> CreateProductAsync(Product product)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "Product", product);

            return response;
        }

        public static async Task<Product> GetProductAsync(string path)
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }

        public static async Task<HttpResponseMessage> UpdateProductAsync(Product product)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"Product/{product.Id}", product);
           
            // Deserialize the updated product from the response body.
            product = await response.Content.ReadAsAsync<Product>();
            MessageBox.Show(response.StatusCode.ToString());
            return response;
        }

        public static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"Product/{id}");
            return response.StatusCode;
            
        }

        public static async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            HttpResponseMessage response = await client.GetAsync("Product");
            var product = await response.Content.ReadAsAsync<IEnumerable<Product>>();

            return product;
        }


    }
}
