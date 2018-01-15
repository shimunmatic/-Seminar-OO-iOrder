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
using System.Net.Http.Headers;
using DesktopApp.controllers;

namespace DesktopApp
{
    public partial class MainForm : Form
    {

        HttpClient client = HttpBuilder.Build();
     
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Tabs.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);

            //get All informations
            setData();

            


        }

        private async void setData()
        {
            //dataGridViewWarehouse.DataSource = await WarehouseController.GetAllWarehouseAsync();
            dataGridViewCategory.DataSource = await CategoryController.GetAllCategoryAsync();
            dataGridViewProduct.DataSource = await ProductController.GetAllProductAsync();
        }



        //poziv get metode kad se pritisne na određeni tab
        private async void Tabs_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (Tabs.SelectedTab == Warehouse)
            {

               
            }
            else if (Tabs.SelectedTab == Category)
            {
                HttpResponseMessage response = await client.GetAsync("Category");
                var category = await response.Content.ReadAsAsync<IEnumerable<CategoryEntity>>();
                dataGridViewCategory.DataSource = category;

            }
            else if (Tabs.SelectedTab == Product)
            {
                HttpResponseMessage response = await client.GetAsync("Product");
                var product = await response.Content.ReadAsAsync<IEnumerable<ProductEntity>>();
                dataGridViewProduct.DataSource = product;

            }
            //Dodaj za ostatak tabova
        }

      

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            AddProductForm popup = new AddProductForm();
            DialogResult dialogresult = popup.ShowDialog();

            popup.Dispose();
        }

        private void UpdateProductButton_Click(object sender, EventArgs e)
        {
            UpdateProductForm popup = new UpdateProductForm();
            DialogResult dialogresult = popup.ShowDialog();

            popup.Dispose();
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
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

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            AddCategoryForm popup = new AddCategoryForm();
            DialogResult dialogresult = popup.ShowDialog();

            popup.Dispose();
        }

        private void UpdateCategoryButton_Click(object sender, EventArgs e)
        {
            //UpdateCategoryForm popup = new UpdateCategoryForm();
            //DialogResult dialogresult = popup.ShowDialog();

            //popup.Dispose();
        }

        private void DeleteCategoryButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                   "Confirm Delete!!",
                                   MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                //nabavi id trenutno označenog redka
                //DeleteCategoryAsync();
            }
            else
            {
                // If 'No', do something here.
            }
        }

        private void AddWarehouseButton_Click(object sender, EventArgs e)
        {
            //AddWarehouseForm popup = new AddWarehouseForm();
            //DialogResult dialogresult = popup.ShowDialog();

            //popup.Dispose();
        }

        private void UpdateWarehouseButton_Click(object sender, EventArgs e)
        {
            //UpdateWarehouseForm popup = new UpdateWarehouseForm();
            //DialogResult dialogresult = popup.ShowDialog();

            //popup.Dispose();
        }

        private void DeleteWarehouseButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                   "Confirm Delete!!",
                                   MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                //nabavi id trenutno označenog redka
                //DeleteWarehouseAsync();
            }
            else
            {
                // If 'No', do something here.
            }
        }
    }
}
