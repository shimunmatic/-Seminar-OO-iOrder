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
		public EmployeeAddForm()
		{
			InitializeComponent();
		}

		private async void confirmButton_Click(object sender, EventArgs e)
		{
			User employee = new User();
			Role role = new Role();
			role.Id = 4;
			role.RoleName = "EMPLOYEE";
			

			employee.Username = textBox11.Text;
			employee.Password = textBox12.Text;
			employee.FirstName = textBox13.Text;
			employee.LastName = textBox14.Text;
			employee.Email = textBox15.Text;
			employee.Role = role;


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
