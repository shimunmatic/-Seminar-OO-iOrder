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

namespace DesktopApp.forms.EmployeeForms
{
	public partial class EmployeeAddForm : Form
	{
		IEnumerable<Establishment> establishmentList;

		public EmployeeAddForm()
		{
			InitializeComponent();
			addDataToForm();
		}

		private async void addDataToForm()
		{
			establishmentList = await MainController.GetAllItemsAsync<Establishment>("Establishment");

			establishmentList.ToList().ForEach(item =>
			{
				comboBox1.Items.Add(item);
			});
			
		}

		private async void confirmButton_Click(object sender, EventArgs e)
		{
			User employee = new User();
		
			employee.Username = textBox11.Text;
			employee.Password = textBox12.Text;
			employee.FirstName = textBox13.Text;
			employee.LastName = textBox14.Text;
			employee.Email = textBox15.Text;


			string EstablishmentName = comboBox1.SelectedItem.ToString();
			long establishmentId = await Establishment.findItem(EstablishmentName);
			employee.EstablishmentId = establishmentId;

			HttpResponseMessage response = await MainController.CreateItemAsync(employee, "User/Employee");
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

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
