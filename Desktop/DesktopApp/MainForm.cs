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
using DesktopApp.forms;
using DesktopApp.forms.CategoryForms;
using DesktopApp.forms.LocationForms;

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


        }

       
        //poziv get metode kad se pritisne na određeni tab
        private async void Tabs_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (Tabs.SelectedTab == Warehouse)
            {
                var warehouse = await MainController.GetAllItemsAsync<Warehouse>("Warehouse");
                dataGridViewWarehouse.DataSource = warehouse;

            }
            else if (Tabs.SelectedTab == Category)
            {
                var category = await MainController.GetAllItemsAsync<Category>("Category");
                dataGridViewCategory.DataSource = category;

            }
            else if (Tabs.SelectedTab == Product)
            {
                var product = await MainController.GetAllItemsAsync<Product>("Product");
                dataGridViewProduct.DataSource = product;


            }
            else if (Tabs.SelectedTab == Establishment)
            {
                var establishment = await MainController.GetAllItemsAsync<Establishment>("Establishment");
                dataGridViewEstablishment.DataSource = establishment;
            }
            else if (Tabs.SelectedTab == Location)
            {
                var location = await MainController.GetAllItemsAsync<Location>("Location");
                dataGridViewLocation.DataSource = location;

            }
            //Dodaj za ostatak tabova
        }

      

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            AddProductForm popup = new AddProductForm();
            DialogResult dialogresult = popup.ShowDialog();

            popup.Dispose();
        }

     
        private async void DeleteProductButton_Click(object sender, EventArgs e)
        {
            MainController.DeleteItem(dataGridViewProduct,"Product");
        }

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            AddCategoryForm popup = new AddCategoryForm();
            DialogResult dialogresult = popup.ShowDialog();

            popup.Dispose();
        }

       
        private void DeleteCategoryButton_Click(object sender, EventArgs e)
        {
            MainController.DeleteItem(dataGridViewCategory, "Category");
        }

        private void AddWarehouseButton_Click(object sender, EventArgs e)
        {
            AddWarehouseForm popup = new AddWarehouseForm();
            DialogResult dialogresult = popup.ShowDialog();

            popup.Dispose();
        }

     
        private void DeleteWarehouseButton_Click(object sender, EventArgs e)
        {
            MainController.DeleteItem(dataGridViewWarehouse, "Warehouse");
        }

        private void LocationAddbutton_Click(object sender, EventArgs e)
        {
            AddLocationForm popup = new AddLocationForm();
            DialogResult dialogresult = popup.ShowDialog();

            popup.Dispose();
        }

        private void LocationDeletebutton_Click(object sender, EventArgs e)
        {
            MainController.DeleteItem(dataGridViewLocation, "Location");
        }

        private async void UpdateProduct_Click(object sender, EventArgs e)
        {
            Product product = new Product();


            product.Name = textBox1.Text;
            product.BuyingPrice = Decimal.Parse(textBox2.Text);
            product.OwnerId = HttpBuilder.getOwner();

            product.CategoryId = Convert.ToInt64(textBox3.Text);
            product.SupplierId = Convert.ToInt64(textBox4.Text);

            product.Id = Convert.ToInt64(textBox5.Text);


            HttpResponseMessage response = await ProductController.UpdateProductAsync(product);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Proizvod je azuriran");

            }

        }

        private void dataGridViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridViewProduct.Rows[index];

            textBox1.Text = selectedRow.Cells[2].Value.ToString();
            textBox2.Text = selectedRow.Cells[3].Value.ToString();
            textBox3.Text = selectedRow.Cells[1].Value.ToString();
            textBox4.Text = selectedRow.Cells[5].Value.ToString();
            textBox5.Text = selectedRow.Cells[0].Value.ToString();

        }

   
        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            Category category = new Category();

            category.Name = UpdatecategorytextBox.Text;
            category.Id = Convert.ToInt64(UpdateCategoryIDtextBox.Text);
            category.OwnerId = HttpBuilder.getOwner();

            HttpResponseMessage response = await CategoryController.UpdateCategoryAsync(category);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Proizvod je azuriran");

            }

        }

        private async void dataGridViewCategory_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridViewCategory.Rows[index];

            UpdatecategorytextBox.Text = selectedRow.Cells[1].Value.ToString();
            UpdateCategoryIDtextBox.Text = selectedRow.Cells[0].Value.ToString();

            var product = await MainController.GetAllItemsAsync<Product>("Product");
            long categoryID = Convert.ToInt64(UpdateCategoryIDtextBox.Text);

            var details = product.Where(p => p.CategoryId == categoryID).ToList();
            dataGridViewCategoryDetail.DataSource = details;

        }

        private void LocationUpdatebutton_Click(object sender, EventArgs e)
        {
            Location location = new Location();

            location.Name = NametextBox.Text;
            location.Id = Convert.ToInt64(IDtextBox.Text);
            location.EstablishmentId = Convert.ToInt64(EstablishmentIDtextBox.Text);

            //HttpResponseMessage response = await CategoryController.UpdateCategoryAsync(category);
            //if (response.IsSuccessStatusCode)
            //{
            //    MessageBox.Show("Lokacija je azurirana");

            //}
        }

        private void dataGridViewLocation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridViewLocation.Rows[index];

            IDtextBox.Text = selectedRow.Cells[0].Value.ToString();
            EstablishmentIDtextBox.Text = selectedRow.Cells[1].Value.ToString();
            NametextBox.Text = selectedRow.Cells[2].Value.ToString();
          
        }

        private void EstablishmentDeletebutton_Click(object sender, EventArgs e)
        {
            MainController.DeleteItem(dataGridViewEstablishment, "Establishment");
        }

        private void EstablishmentAddbutton_Click(object sender, EventArgs e)
        {
            //EstablishmentAddForm popup = new EstablishmentAddForm();
            //DialogResult dialogresult = popup.ShowDialog();

            //popup.Dispose();
        }

        private async void dataGridViewWarehouse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var product = await MainController.GetAllItemsAsync<Product>("Product");
            //long warehouseID = Convert.ToInt64(UpdateCategoryIDtextBox.Text);

            //var details = product.Where(p => p.CategoryId == warehouseID).ToList();
            //dataGridViewCategoryDetail.DataSource = details;
        }
    }
}
