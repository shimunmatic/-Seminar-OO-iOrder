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

namespace DesktopApp.forms.LocationForms
{
   
    public partial class AddLocationForm : Form
    {
        IEnumerable<Establishment> establishmentList;
        public AddLocationForm()
        {
            InitializeComponent();
            addDataToForm();
        }

        private async void confirmButton_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Name = textBox1.Text;


            string LocationName = comboBox1.SelectedItem.ToString();
            long establishmentId = findEstablishment(LocationName, establishmentList);
            location.EstablishmentId = establishmentId;


            HttpResponseMessage response = await MainController.CreateItemAsync(location, "Location");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Dodavanje uspjelo");

            }

            this.Close();
        }


        private async void addDataToForm()
        {
            establishmentList = await MainController.GetAllItemsAsync<Establishment>("Establishment");



            establishmentList.ToList().ForEach(item =>
            {
                comboBox1.Items.Add(item);
            });
           
        }
        private long findEstablishment(string name, IEnumerable<Establishment> list)
        {
            return list.First(c => c.Name == name).Id;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
