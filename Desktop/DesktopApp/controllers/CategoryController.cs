using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.controllers
{
    class CategoryController
    {
        
        static async Task<Uri> CreateCategoryAsync(CategoryEntity category, HttpClient client)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/categorys", category);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<CategoryEntity> GetCategoryAsync(string path, HttpClient client)
        {
            CategoryEntity category = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                category = await response.Content.ReadAsAsync<CategoryEntity>();
            }
            return category;
        }

        static async Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category, HttpClient client)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/categorys/{category.Id}", category);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            category = await response.Content.ReadAsAsync<CategoryEntity>();
            return category;
        }

        static async Task<HttpStatusCode> DeleteCategoryAsync(string id, HttpClient client)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/categorys/{id}");
            return response.StatusCode;
        }

    }
}

