using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.forms
{
    public partial class AddWarehouseForm : Form
    {
        public AddWarehouseForm()
        {
            InitializeComponent();
        }

        private async void confirmButton_Click(object sender, EventArgs e)
        {
            Warehouse warehouse = new Warehouse();

            warehouse.Address = textBox1.Text;
            warehouse.Zip = textBox2.Text;
            warehouse.City = textBox3.Text;
            warehouse.OwnerId = HttpBuilder.getOwner();


           

            HttpResponseMessage response = await MainController.CreateItemAsync(warehouse, "Warehouse");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Skladiste je dodano");

            }

            this.Close();
        }
    }
}
