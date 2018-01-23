using DesktopApp.controllers;
using DesktopApp.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class AddProductForm : Form
    {

        IEnumerable<Category> categoryList;
        IEnumerable<Supplier> supplierList;
        public AddProductForm()
        {
            InitializeComponent();
            //popuni sve comboBoxove sa podacima

            addDataToForm();
        }

        private async void addDataToForm()
        {
            categoryList = await MainController.GetAllItemsAsync<Category>("Category");
            supplierList = await MainController.GetAllItemsAsync<Supplier>("Supplier");

            categoryList.ToList().ForEach(item =>
            {
                comboBox1.Items.Add(item);
            });
            supplierList.ToList().ForEach(item =>
            {
                comboBox2.Items.Add(item);
            });
        }

        private async void confirmButton_Click(object sender, EventArgs e)
        {

            //add some data control

            bool validData = validateData();

            if (validData)
            {
                Product product = new Product();

                product.Name = textBox1.Text;
                product.BuyingPrice = Decimal.Parse(textBox2.Text);
                product.OwnerId = HttpBuilder.getOwner();

                string CategoryName = comboBox1.SelectedItem.ToString();
                long categoryId = findCategory(CategoryName, categoryList);
                product.CategoryId = categoryId;

                string SupplierName = comboBox2.SelectedItem.ToString();
                long supplierid = findSupplier(SupplierName, supplierList);
                product.SupplierId = supplierid;



				HttpResponseMessage response = await MainController.CreateItemAsync(product, "Product");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Dodavanje uspjelo");

                }
                else {
                    MessageBox.Show(response.StatusCode.ToString());
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill all data in form");
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool validateData()
        {
            bool validData = true;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textbox = control as TextBox;
                    validData &= !string.IsNullOrWhiteSpace(textbox.Text);
                }
            }
            return validData;
           
        }

        private long findCategory(string name, IEnumerable<Category> list)
        {
            return list.First(c => c.Name == name).Id;

        }

        private long findSupplier(string name, IEnumerable<Supplier> list)
        {
            return list.First(c => c.Name == name).Id;

        }
    }
}
