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
        public static async Task<HttpResponseMessage> CreateCategoryAsync(Category category)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "Category", category);
           
            return response;
        }

        public static async Task<Category> GetCategoryAsync(string path)
        {
            Category category = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                category = await response.Content.ReadAsAsync<Category>();
            }
            return category;
        }

        public static async Task<HttpResponseMessage> UpdateCategoryAsync(Category category)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"Category/{category.Id}", category);
          

            // Deserialize the updated product from the response body.
            category = await response.Content.ReadAsAsync<Category>();
            return response;
        }

        public static async Task<HttpStatusCode> DeleteCategoryAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"Category/{id}");
            return response.StatusCode;
        }

        public static async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            HttpResponseMessage response = await client.GetAsync("Category");
            var category = await response.Content.ReadAsAsync<IEnumerable<Category>>();
            return category;
        }

    }
}

