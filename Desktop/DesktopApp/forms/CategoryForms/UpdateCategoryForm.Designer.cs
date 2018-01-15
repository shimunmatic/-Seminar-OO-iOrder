namespace DesktopApp.forms.CategoryForms
{
    partial class UpdateCategoryForm
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
            this.CategorySupplierComboBox = new System.Windows.Forms.ComboBox();
            this.category = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CategoryBuyingPriceTextBox = new System.Windows.Forms.TextBox();
            this.CategoryNameTextBox = new System.Windows.Forms.TextBox();
            this.Name = new System.Windows.Forms.Label();
            Buying_price = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(163, 199);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 37;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(82, 199);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 36;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // CategorySupplierComboBox
            // 
            this.CategorySupplierComboBox.FormattingEnabled = true;
            this.CategorySupplierComboBox.Location = new System.Drawing.Point(117, 118);
            this.CategorySupplierComboBox.Name = "CategorySupplierComboBox";
            this.CategorySupplierComboBox.Size = new System.Drawing.Size(121, 21);
            this.CategorySupplierComboBox.TabIndex = 35;
            // 
            // category
            // 
            this.category.AutoSize = true;
            this.category.Location = new System.Drawing.Point(62, 94);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(49, 13);
            this.category.TabIndex = 33;
            this.category.Text = "Category";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(117, 91);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Supplier";
            // 
            // CategoryBuyingPriceTextBox
            // 
            this.CategoryBuyingPriceTextBox.Location = new System.Drawing.Point(117, 64);
            this.CategoryBuyingPriceTextBox.Name = "CategoryBuyingPriceTextBox";
            this.CategoryBuyingPriceTextBox.Size = new System.Drawing.Size(121, 20);
            this.CategoryBuyingPriceTextBox.TabIndex = 30;
            // 
            // CategoryNameTextBox
            // 
            this.CategoryNameTextBox.Location = new System.Drawing.Point(117, 38);
            this.CategoryNameTextBox.Name = "CategoryNameTextBox";
            this.CategoryNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.CategoryNameTextBox.TabIndex = 29;
            // 
            // Buying_price
            // 
            Buying_price.AutoSize = true;
            Buying_price.Location = new System.Drawing.Point(46, 67);
            Buying_price.Name = "Buying_price";
            Buying_price.Size = new System.Drawing.Size(65, 13);
            Buying_price.TabIndex = 27;
            Buying_price.Text = "Buying price";
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(76, 41);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(35, 13);
            this.Name.TabIndex = 26;
            this.Name.Text = "Name";
            // 
            // UpdateCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.CategorySupplierComboBox);
            this.Controls.Add(this.category);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CategoryBuyingPriceTextBox);
            this.Controls.Add(this.CategoryNameTextBox);
            this.Controls.Add(Buying_price);
            this.Controls.Add(this.Name);
  
            this.Text = "UpdateCategoryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.ComboBox CategorySupplierComboBox;
        private System.Windows.Forms.Label category;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CategoryBuyingPriceTextBox;
        private System.Windows.Forms.TextBox CategoryNameTextBox;
        private System.Windows.Forms.Label Name;
    }
}