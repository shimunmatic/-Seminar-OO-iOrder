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

namespace DesktopApp.forms.CategoryForms
{
    public partial class AddCategoryForm : Form
    {
        public AddCategoryForm()
        {
            InitializeComponent();
        }

        private async void confirmButton_Click(object sender, EventArgs e)
        {
            Category category = new Category();

            category.Name = textBox1.Text;
            category.OwnerId = HttpBuilder.getOwner();

            HttpResponseMessage response = await MainController.CreateItemAsync(category, "Category");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Kategorija je dodana");

            }

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
