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
using DesktopApp.forms.EstablishmentForms;
using DesktopApp.forms.EmployeeForms;

namespace DesktopApp
{
    public partial class MainForm : Form
    {

        HttpClient client = HttpBuilder.Build();
		IEnumerable<Warehouse> warehouseList;



		public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            InitializefirstWiew();
           
            Tabs.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);


        }

       
        private async void InitializefirstWiew()
        {
            var warehouse = await MainController.GetAllItemsAsync<Warehouse>("Warehouse");
            dataGridViewWarehouse.DataSource = warehouse;
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
				fillDataInProductView();

				var WProduct = await MainController.GetAllItemsAsync<WarehouseProduct>("Product/Storage/1");
				foreach (var item in WProduct)
				{
					MessageBox.Show(item.ToString());
				}


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
			else if (Tabs.SelectedTab == Employee)
			{
				var employee = await MainController.GetAllItemsAsync<User>("User/Employee");
				//foreach (var item in employee)
				dataGridViewEmployee.DataSource = employee;

			}
			
		}

      
		//--------ADD item section
        private async void AddProductButton_Click(object sender, EventArgs e)
        {
            AddProductForm popup = new AddProductForm();
            DialogResult dialogresult = popup.ShowDialog();

            popup.Dispose();

			var product = await MainController.GetAllItemsAsync<Product>("Product");
			dataGridViewProduct.DataSource = product;
		}

		private async void AddCategoryButton_Click(object sender, EventArgs e)
		{
			AddCategoryForm popup = new AddCategoryForm();
			DialogResult dialogresult = popup.ShowDialog();

			popup.Dispose();

			var category = await MainController.GetAllItemsAsync<Category>("Category");
			dataGridViewCategory.DataSource = category;
		}

		private async void AddWarehouseButton_Click(object sender, EventArgs e)
		{
			AddWarehouseForm popup = new AddWarehouseForm();
			DialogResult dialogresult = popup.ShowDialog();

			popup.Dispose();

			var warehouse = await MainController.GetAllItemsAsync<Warehouse>("Warehouse");
			dataGridViewWarehouse.DataSource = warehouse;
		}
		private async void LocationAddbutton_Click(object sender, EventArgs e)
		{
			AddLocationForm popup = new AddLocationForm();
			DialogResult dialogresult = popup.ShowDialog();

			popup.Dispose();

			var location = await MainController.GetAllItemsAsync<Location>("Location");
			dataGridViewLocation.DataSource = location;
		}

		private async void EstablishmentAddbutton_Click(object sender, EventArgs e)
		{
			EstablishmentAddForm popup = new EstablishmentAddForm();
			DialogResult dialogresult = popup.ShowDialog();

			popup.Dispose();

			var establishment = await MainController.GetAllItemsAsync<Establishment>("Establishment");
			dataGridViewEstablishment.DataSource = establishment;
		}
		private async void AddEmployeeButton_Click(object sender, EventArgs e)
		{
			EmployeeAddForm popup = new EmployeeAddForm();
			DialogResult dialogresult = popup.ShowDialog();

			popup.Dispose();

			var employee = await MainController.GetAllItemsAsync<User>("User/Employee");
			dataGridViewEmployee.DataSource = employee;
		}

		private async void AddToWerehouseButton_Click(object sender, EventArgs e)
		{

			WarehouseProduct wproduct = new WarehouseProduct();
			wproduct.ProductId = Convert.ToInt64(textBox5.Text);
			wproduct.WearhouseId = Convert.ToInt64(comboBox1.SelectedItem.ToString());
			wproduct.Quantity = Convert.ToInt32(textBox6.Text);
			wproduct.SellingPrice = Decimal.Parse(textBox7.Text);


			HttpResponseMessage response = await MainController.CreateItemAsync(wproduct, "Product/Storage");
			if (response.IsSuccessStatusCode)
			{
				MessageBox.Show("Dodavanje uspjelo");

			}
			else
			{
				MessageBox.Show(response.StatusCode.ToString());
			}
		}
		//--------END of ADD item section

		//--------DELETE item section




		private async void DeleteProductButton_Click(object sender, EventArgs e)
        {
            MainController.DeleteItem(dataGridViewProduct,"Product");

			var product = await MainController.GetAllItemsAsync<Product>("Product");
			dataGridViewProduct.DataSource = product;
		}

      

       
        private async void DeleteCategoryButton_Click(object sender, EventArgs e)
        {
            MainController.DeleteItem(dataGridViewCategory, "Category");

			var category = await MainController.GetAllItemsAsync<Category>("Category");
			dataGridViewCategory.DataSource = category;
		}

       

     
        private async void DeleteWarehouseButton_Click(object sender, EventArgs e)
        {
            MainController.DeleteItem(dataGridViewWarehouse, "Warehouse");

			var warehouse = await MainController.GetAllItemsAsync<Warehouse>("Warehouse");
			dataGridViewWarehouse.DataSource = warehouse;
		}

       

        private async void LocationDeletebutton_Click(object sender, EventArgs e)
        {
            MainController.DeleteItem(dataGridViewLocation, "Location");

			var location = await MainController.GetAllItemsAsync<Location>("Location");
			dataGridViewLocation.DataSource = location;
		}

		private async void EstablishmentDeletebutton_Click(object sender, EventArgs e)
		{
			MainController.DeleteItem(dataGridViewEstablishment, "Establishment");

			var establishment = await MainController.GetAllItemsAsync<Establishment>("Establishment");
			dataGridViewEstablishment.DataSource = establishment;
		}


		private async void DeleteEmployeeButton_Click(object sender, EventArgs e)
		{
			MainController.DeleteItem(dataGridViewEmployee, "User/Employee");

			var employee = await MainController.GetAllItemsAsync<User>("User/Employee");
			dataGridViewEmployee.DataSource = employee;
		}


		//--------END of DELETE item section





		//--------UPDATE item section


		








		private async void UpdateProduct_Click(object sender, EventArgs e)
        {
            Product product = new Product();


            product.Name = textBox1.Text;
            product.BuyingPrice = Decimal.Parse(textBox2.Text);
            product.OwnerId = HttpBuilder.getOwner();

            product.CategoryId = Convert.ToInt64(textBox3.Text);
            product.SupplierId = Convert.ToInt64(textBox4.Text);

            product.Id = Convert.ToInt64(textBox5.Text);

            HttpResponseMessage response = await MainController.UpdateItemAsync(product,product.Id, "Product");
			if (response.IsSuccessStatusCode)
			{
				MessageBox.Show("Proizvod je azuriran");

				var products = await MainController.GetAllItemsAsync<Product>("Product");
				dataGridViewProduct.DataSource = products;

			}
			else {
				MessageBox.Show(response.StatusCode.ToString());
			}

        }



		private async void UpdateButton_Click(object sender, EventArgs e)
		{
			Category category = new Category();

			category.Name = UpdatecategorytextBox.Text;
			category.Id = Convert.ToInt64(UpdateCategoryIDtextBox.Text);
			category.OwnerId = HttpBuilder.getOwner();

			HttpResponseMessage response = await MainController.UpdateItemAsync(category, category.Id, "Category");
			if (response.IsSuccessStatusCode)
			{
				MessageBox.Show("Proizvod je azuriran");
				var categorys = await MainController.GetAllItemsAsync<Category>("Category");
				dataGridViewCategory.DataSource = categorys;

			}
			else
			{
				MessageBox.Show(response.StatusCode.ToString());
			}

		}


		private async void LocationUpdatebutton_Click(object sender, EventArgs e)
		{
			Location location = new Location();

			location.Name = NametextBox.Text;
			location.Id = Convert.ToInt64(IDtextBox.Text);
			location.EstablishmentId = Convert.ToInt64(EstablishmentIDtextBox.Text);

			HttpResponseMessage response = await MainController.UpdateItemAsync(location, location.Id,"Location");
			if (response.IsSuccessStatusCode)
			{
				MessageBox.Show("Lokacija je azurirana");

				var locations = await MainController.GetAllItemsAsync<Location>("Location");
				dataGridViewLocation.DataSource = locations;

			}
		}




		private async void EmployeeUpdateButton_Click(object sender, EventArgs e)
		{
			User employee = new User();
			Role role = new Role();

			role.Id = 4;
			role.RoleName = "EMPLOYEE";

			employee.Username = textBox10.Text;
			employee.Password = textBox11.Text;
			employee.FirstName = textBox12.Text;
			employee.LastName = textBox13.Text;
			employee.Email = textBox14.Text;
			employee.Role = role;

			//pitanje kak složit update -> nema na backendu rute
			//HttpResponseMessage response = await MainController.UpdateItemAsync(employee, employee.Username, "User/Employee");
			//if (response.IsSuccessStatusCode)
			//{
			//	MessageBox.Show("Azuriranje uspjelo!");
			//var employees = await MainController.GetAllItemsAsync<User>("User/Employee");
			//dataGridViewEmployee.DataSource = employees;

			//}
		}
		//--------END of UPDATE item section








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


        private void dataGridViewLocation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridViewLocation.Rows[index];

            IDtextBox.Text = selectedRow.Cells[0].Value.ToString();
            EstablishmentIDtextBox.Text = selectedRow.Cells[1].Value.ToString();
            NametextBox.Text = selectedRow.Cells[2].Value.ToString();
          
        }

      
      

        private async void dataGridViewWarehouse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var product = await MainController.GetAllItemsAsync<Product>("Product");
            //long warehouseID = Convert.ToInt64(UpdateCategoryIDtextBox.Text);

            //var details = product.Where(p => p.CategoryId == warehouseID).ToList();
            //dataGridViewCategoryDetail.DataSource = details;
        }

		



		private void dataGridViewEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			int index = e.RowIndex;
			DataGridViewRow selectedRow = dataGridViewEmployee.Rows[index];

			textBox10.Text = selectedRow.Cells[0].Value.ToString();
			textBox11.Text = selectedRow.Cells[2].Value.ToString();
			textBox12.Text = selectedRow.Cells[3].Value.ToString();
			textBox13.Text = selectedRow.Cells[4].Value.ToString();
			textBox14.Text = selectedRow.Cells[5].Value.ToString();
		}

		

		private async void fillDataInProductView()
		{
			warehouseList = await MainController.GetAllItemsAsync<Warehouse>("Warehouse");

			warehouseList.ToList().ForEach(item =>
			{
				comboBox1.Items.Add(item);
			});
		}

	}
}
