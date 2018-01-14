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
            //popuni sve comboBoxove sa podacima
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

            //add some data control

            bool validData = validateData();

            if (validData)
            {
                ProductEntity product = new ProductEntity();


                product.Name = textBox1.Text;
                product.BuyingPrice = Decimal.Parse(textBox2.Text);

                //treba uzet id od selected item
                //product.CategoryId = comboBox1.SelectedItem;
                //product.OwnerId = spremi svoj id
                //product.SupplierId = comboBox3.SelectedItem;

                //ProductController.CreateProductAsync(product);

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
    }
}
