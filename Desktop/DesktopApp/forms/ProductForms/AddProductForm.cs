using DesktopApp.controllers;
using DesktopApp.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

           //add some data control

            ProductEntity product = new ProductEntity();
            product.Name = textBox1.Text;
            product.BuyingPrice = Decimal.Parse(textBox2.Text);

            //treba uzet id od selected item
            //product.CategoryId = comboBox1.SelectedItem;
            //product.OwnerId = comboBox2.SelectedItem;
            //product.SupplierId = comboBox3.SelectedItem;

            //ProductController.CreateProductAsync(product);
            this.Close();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
