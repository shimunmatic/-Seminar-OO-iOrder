using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Formatting;
using DesktopApp.models;
using System.Net;

namespace DesktopApp
{
    public partial class MainForm : Form
    {

        static HttpClient client;
        public MainForm()
        {
            InitializeComponent();
            Tabs.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);
            client = new HttpClient();
            //client.BaseAddress = new Uri("/proba");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //poziv get metode kad se pritisne na određeni tab
        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)

        {
            

            //if (Tabs.SelectedTab == Warehouse)
            //{
                
            //    HttpResponseMessage response = client.GetAsync("ostatak uri").Result;
            //    var warehouse = response.Content.ReadAsAsync<IEnumerable<WarehouseEntity>>().Result;
            //    dataGridView1.DataSource = warehouse;
            //}
            //else if (Tabs.SelectedTab == Category)
            //{
            //    HttpResponseMessage response = client.GetAsync("ostatak uri").Result;
            //    var category = response.Content.ReadAsAsync<IEnumerable<CategoryEntity>>().Result;
            //    dataGridView2.DataSource = category;
            //}
            //else if (Tabs.SelectedTab == Product)
            //{
            //    HttpResponseMessage response = client.GetAsync("ostatak uri").Result;
            //    var product = response.Content.ReadAsAsync<IEnumerable<ProductEntity>>().Result;
            //    dataGridView2.DataSource = product;
            //}
            //Dodaj za ostatak tabova
        }

        private void AddButton1_Click(object sender, EventArgs e)
        {
            AddProductForm popup = new AddProductForm();
            DialogResult dialogresult = popup.ShowDialog();
            
            popup.Dispose();
        }

        private void UpdateButton1_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton1_Click(object sender, EventArgs e)
        {

        }


        private void AddButton2_Click(object sender, EventArgs e)
        {
            AddCategoryForm popup = new AddCategoryForm();
            DialogResult dialogresult = popup.ShowDialog();

            popup.Dispose();
        }

        private void UpdateButton2_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton2_Click(object sender, EventArgs e)
        {

        }

        private void AddButton3_Click(object sender, EventArgs e)
        {
            AddProductForm popup = new AddProductForm();
            DialogResult dialogresult = popup.ShowDialog();

            popup.Dispose();
        }


        private void UpdateButton3_Click(object sender, EventArgs e)
        {
            UpdateProductForm popup = new UpdateProductForm();
            DialogResult dialogresult = popup.ShowDialog();

            popup.Dispose();
        }

        private void DeleteButton3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                //nabavi id trenutno označenog redka
                //DeleteProductAsync();
            }
            else
            {
                // If 'No', do something here.
            }
        }

       
    }
}
