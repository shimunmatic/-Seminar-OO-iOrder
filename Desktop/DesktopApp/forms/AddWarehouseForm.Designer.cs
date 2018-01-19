namespace DesktopApp.forms
{
    partial class AddWarehouseForm
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
            System.Windows.Forms.Label Buying_price;
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.category = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Name = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            Buying_price = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(163, 184);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 23;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(82, 184);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 22;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // category
            // 
            this.category.AutoSize = true;
            this.category.Location = new System.Drawing.Point(66, 109);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(24, 13);
            this.category.TabIndex = 20;
            this.category.Text = "City";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(117, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 20);
            this.textBox2.TabIndex = 17;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(117, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 16;
            // 
            // Buying_price
            // 
            Buying_price.AutoSize = true;
            Buying_price.Location = new System.Drawing.Point(66, 83);
            Buying_price.Name = "Buying_price";
            Buying_price.Size = new System.Drawing.Size(22, 13);
            Buying_price.TabIndex = 15;
            Buying_price.Text = "Zip";
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(66, 57);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(45, 13);
            this.Name.TabIndex = 14;
            this.Name.Text = "Address";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(117, 106);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(121, 20);
            this.textBox3.TabIndex = 24;
            // 
            // AddWarehouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.category);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(Buying_price);
            this.Controls.Add(this.Name);
        
            this.Text = "AddWarehouseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label category;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.TextBox textBox3;
    }
}