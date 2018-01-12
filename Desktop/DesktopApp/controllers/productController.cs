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
   
    class ProductController
    {
        static async Task<Uri> CreateProductAsync(ProductEntity product, HttpClient client)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/products", product);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<ProductEntity> GetProductAsync(string path, HttpClient client)
        {
            ProductEntity product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<ProductEntity>();
            }
            return product;
        }

        static async Task<ProductEntity> UpdateProductAsync(ProductEntity product, HttpClient client)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/products/{product.Id}", product);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            product = await response.Content.ReadAsAsync<ProductEntity>();
            return product;
        }

        static async Task<HttpStatusCode> DeleteProductAsync(string id, HttpClient client)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/products/{id}");
            return response.StatusCode;
        }

    }
}
