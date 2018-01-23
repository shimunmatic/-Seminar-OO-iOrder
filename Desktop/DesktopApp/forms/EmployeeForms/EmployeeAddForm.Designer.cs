namespace DesktopApp.forms.EmployeeForms
{
	partial class EmployeeAddForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.confirmButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox15
			// 
			this.textBox15.Location = new System.Drawing.Point(82, 124);
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(121, 20);
			this.textBox15.TabIndex = 40;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(12, 127);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(32, 13);
			this.label20.TabIndex = 39;
			this.label20.Text = "Email";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(11, 99);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(58, 13);
			this.label13.TabIndex = 38;
			this.label13.Text = "Last Name";
			// 
			// textBox14
			// 
			this.textBox14.Location = new System.Drawing.Point(82, 96);
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new System.Drawing.Size(121, 20);
			this.textBox14.TabIndex = 37;
			// 
			// textBox13
			// 
			this.textBox13.Location = new System.Drawing.Point(82, 69);
			this.textBox13.Name = "textBox13";
			this.textBox13.Size = new System.Drawing.Size(121, 20);
			this.textBox13.TabIndex = 36;
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(82, 42);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(121, 20);
			this.textBox12.TabIndex = 35;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(11, 45);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(53, 13);
			this.label16.TabIndex = 34;
			this.label16.Text = "Password";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(11, 72);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(57, 13);
			this.label17.TabIndex = 33;
			this.label17.Text = "First Name";
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(82, 16);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(121, 20);
			this.textBox11.TabIndex = 31;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(11, 16);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(55, 13);
			this.label19.TabIndex = 29;
			this.label19.Text = "Username";
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(128, 161);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 42;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// confirmButton
			// 
			this.confirmButton.Location = new System.Drawing.Point(44, 161);
			this.confirmButton.Name = "confirmButton";
			this.confirmButton.Size = new System.Drawing.Size(75, 23);
			this.confirmButton.TabIndex = 41;
			this.confirmButton.Text = "Confirm";
			this.confirmButton.UseVisualStyleBackColor = true;
			this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
			// 
			// EmployeeAddForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(257, 253);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.confirmButton);
			this.Controls.Add(this.textBox15);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.textBox14);
			this.Controls.Add(this.textBox13);
			this.Controls.Add(this.textBox12);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.textBox11);
			this.Controls.Add(this.label19);
			this.Name = "EmployeeAddForm";
			this.Text = "EmployeeAddForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox15;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button confirmButton;
	}
}