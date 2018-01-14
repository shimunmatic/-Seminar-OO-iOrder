using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.controllers
{
    class CategoryController {
        
        static HttpClient client = HttpBuilder.Build();
        public static async Task<HttpResponseMessage> CreateCategoryAsync(CategoryEntity category)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "Category", category);
           
            return response;
        }

        public static async Task<CategoryEntity> GetCategoryAsync(string path)
        {
            CategoryEntity category = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                category = await response.Content.ReadAsAsync<CategoryEntity>();
            }
            return category;
        }

        public static async Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"Category/{category.Id}", category);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            category = await response.Content.ReadAsAsync<CategoryEntity>();
            return category;
        }

        public static async Task<HttpStatusCode> DeleteCategoryAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"Category/{id}");
            return response.StatusCode;
        }

        public static async Task<IEnumerable<CategoryEntity>> GetAllCategoryAsync()
        {
            HttpResponseMessage response = await client.GetAsync("Category");
            var category = await response.Content.ReadAsAsync<IEnumerable<CategoryEntity>>();
            return category;
        }

    }
}

