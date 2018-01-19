using DesktopApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    static class MainController
    {
        static HttpClient client = HttpBuilder.Build();


        public static async Task<IEnumerable<T>> GetAllItemsAsync<T>(string itemType)
        {
            HttpResponseMessage response = await client.GetAsync(itemType);
            var item = await response.Content.ReadAsAsync<IEnumerable<T>>();
            return item;


        }

        //pogledaj kolko dobro radi??
        public static async Task<HttpResponseMessage> UpdateItemAsync(ItemInterface item,long itemID, string newItemType)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"{newItemType}/{itemID}", item);


            // Deserialize the updated product from the response body.
            item = await response.Content.ReadAsAsync<ItemInterface>();
            return response;
        }

        public static async Task<HttpResponseMessage> CreateItemAsync(ItemInterface item, string newItemType )
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
               newItemType, item);

            return response;
        }


        public async static void DeleteItem(DataGridView view, String delItemType)
        {
            var confirmResult = GetConfirmResult();
            if (confirmResult == DialogResult.Yes)
            {
                int index = view.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = view.Rows[index];

                string idForDelete = selectedRow.Cells[0].Value.ToString();

                HttpResponseMessage response = await client.DeleteAsync(
                $"{delItemType}/{idForDelete}");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    MessageBox.Show("Brisanje uspjelo");
                }

            }
            else
            {
                // If 'No', do something here.
            }
        }

        private static DialogResult GetConfirmResult()
        {
            return MessageBox.Show("Are you sure to delete this item ??",
                                              "Confirm Delete!!",
                                              MessageBoxButtons.YesNo);
        }
    }
}
