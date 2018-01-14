using DesktopApp.controllers;
using DesktopApp.models;
using Newtonsoft.Json;
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

namespace DesktopApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            HttpBuilder.Init();

        }

        private async void loginButton_ClickAsync(object sender, EventArgs e)
        {
            UserCredentials userCredentials = new UserCredentials();
            userCredentials.Username = textBox1.Text;
            userCredentials.Password = textBox2.Text;
            HttpResponseMessage response = await AuthController.SendAuthInfoAsync(userCredentials);



            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = await response.Content.ReadAsStringAsync();
                Token t = JsonConvert.DeserializeObject<Token>(json);
                HttpBuilder.AddHeader(t.AccessToken);

                this.Hide();
                MainForm main = new MainForm();
                main.Show();


            }
            else
            {

                MessageBox.Show("Wrong username or password!");
            }


          
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
