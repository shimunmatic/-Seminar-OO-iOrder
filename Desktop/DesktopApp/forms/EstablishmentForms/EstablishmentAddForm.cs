using DesktopApp.models;
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

namespace DesktopApp.forms.EstablishmentForms
{
    public partial class EstablishmentAddForm : Form
    {

        IEnumerable<Warehouse> warehouseList;
        public EstablishmentAddForm()
        {
            InitializeComponent();
            addDataToForm();
        }

        private async void addDataToForm()
        {
            warehouseList = await MainController.GetAllItemsAsync<Warehouse>("Warehouse");

            warehouseList.ToList().ForEach(item =>
            {
                comboBox1.Items.Add(item);
            });
          
        }

        private async void confirmButton_Click(object sender, EventArgs e)
        {
            Establishment establishment = new Establishment();

            establishment.Name = textBox1.Text;
            establishment.Address = textBox2.Text;
            establishment.Zip = textBox3.Text;
            establishment.City = textBox4.Text;
            establishment.OwnerId = HttpBuilder.getOwner();
            establishment.WarehouseId =Convert.ToInt64(comboBox1.SelectedItem.ToString());
            
            HttpResponseMessage response = await MainController.CreateItemAsync(establishment, "Establishment");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Dodavanje uspjelo");

            }
            else
            {
                MessageBox.Show(response.StatusCode.ToString());
            }

            this.Close();
        }
       
    }
}
