namespace DesktopApp.forms.EstablishmentForms
{
    partial class EstablishmentAddForm
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
            System.Windows.Forms.Label Warehouse;
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.category = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Name = new System.Windows.Forms.Label();
            Warehouse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(117, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 30;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(117, 112);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(121, 20);
            this.textBox5.TabIndex = 29;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(117, 85);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(121, 20);
            this.textBox4.TabIndex = 28;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(117, 138);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(121, 20);
            this.textBox3.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "City";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(163, 205);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 25;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(79, 205);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 24;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // category
            // 
            this.category.AutoSize = true;
            this.category.Location = new System.Drawing.Point(46, 88);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(45, 13);
            this.category.TabIndex = 23;
            this.category.Text = "Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Zip";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(117, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 21;
            // 
            // Warehouse
            // 
            Warehouse.AutoSize = true;
            Warehouse.Location = new System.Drawing.Point(46, 61);
            Warehouse.Name = "Warehouse";
            Warehouse.Size = new System.Drawing.Size(62, 13);
            Warehouse.TabIndex = 20;
            Warehouse.Text = "Warehouse";
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(46, 35);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(35, 13);
            this.Name.TabIndex = 19;
            this.Name.Text = "Name";
            // 
            // EstablishmentAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.category);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(Warehouse);
            this.Controls.Add(this.Name);
         
            this.Text = "EstablishmentAddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label category;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Name;
    }
}