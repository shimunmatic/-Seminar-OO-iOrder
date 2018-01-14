namespace DesktopApp
{
    partial class MainForm
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
            this.Tabs = new System.Windows.Forms.TabControl();
            this.Warehouse = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewWarehouse = new System.Windows.Forms.DataGridView();
            this.dataGridViewWarehouseDetail = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.AddWarehouseButton = new System.Windows.Forms.Button();
            this.UpdateWarehouseButton = new System.Windows.Forms.Button();
            this.DeleteWarehouseButton = new System.Windows.Forms.Button();
            this.Category = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewCategory = new System.Windows.Forms.DataGridView();
            this.dataGridViewCategoryDetail = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.AddCategoryButton = new System.Windows.Forms.Button();
            this.UpdateCategoryButton = new System.Windows.Forms.Button();
            this.DeleteCategoryButton = new System.Windows.Forms.Button();
            this.Product = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.dataGridViewProductDetail = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.AddProductButton = new System.Windows.Forms.Button();
            this.UpdateProductButton = new System.Windows.Forms.Button();
            this.DeleteProductButton = new System.Windows.Forms.Button();
            this.Tabs.SuspendLayout();
            this.Warehouse.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouseDetail)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.Category.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategoryDetail)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.Product.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductDetail)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.Tabs.Controls.Add(this.Warehouse);
            this.Tabs.Controls.Add(this.Category);
            this.Tabs.Controls.Add(this.Product);
            this.Tabs.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(917, 461);
            this.Tabs.TabIndex = 0;
            this.Tabs.Tag = "";
            // 
            // Warehouse
            // 
            this.Warehouse.Controls.Add(this.tableLayoutPanel1);
            this.Warehouse.Location = new System.Drawing.Point(4, 25);
            this.Warehouse.Name = "Warehouse";
            this.Warehouse.Padding = new System.Windows.Forms.Padding(3);
            this.Warehouse.Size = new System.Drawing.Size(909, 432);
            this.Warehouse.TabIndex = 0;
            this.Warehouse.Text = "Warehouse";
            this.Warehouse.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewWarehouse, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewWarehouseDetail, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.10798F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.89202F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(903, 426);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataGridViewWarehouse
            // 
            this.dataGridViewWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWarehouse.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewWarehouse.Name = "dataGridViewWarehouse";
            this.dataGridViewWarehouse.Size = new System.Drawing.Size(445, 330);
            this.dataGridViewWarehouse.TabIndex = 0;
   
            // 
            // dataGridViewWarehouseDetail
            // 
            this.dataGridViewWarehouseDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarehouseDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWarehouseDetail.Location = new System.Drawing.Point(454, 3);
            this.dataGridViewWarehouseDetail.Name = "dataGridViewWarehouseDetail";
            this.dataGridViewWarehouseDetail.Size = new System.Drawing.Size(446, 330);
            this.dataGridViewWarehouseDetail.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.AddWarehouseButton);
            this.flowLayoutPanel3.Controls.Add(this.UpdateWarehouseButton);
            this.flowLayoutPanel3.Controls.Add(this.DeleteWarehouseButton);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 339);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(445, 84);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // AddWarehouseButton
            // 
            this.AddWarehouseButton.Location = new System.Drawing.Point(3, 3);
            this.AddWarehouseButton.Name = "AddWarehouseButton";
            this.AddWarehouseButton.Size = new System.Drawing.Size(75, 23);
            this.AddWarehouseButton.TabIndex = 0;
            this.AddWarehouseButton.Text = "Add";
            this.AddWarehouseButton.UseVisualStyleBackColor = true;
            this.AddWarehouseButton.Click += new System.EventHandler(this.AddWarehouseButton_Click);
            // 
            // UpdateWarehouseButton
            // 
            this.UpdateWarehouseButton.Location = new System.Drawing.Point(84, 3);
            this.UpdateWarehouseButton.Name = "UpdateWarehouseButton";
            this.UpdateWarehouseButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateWarehouseButton.TabIndex = 1;
            this.UpdateWarehouseButton.Text = "Update";
            this.UpdateWarehouseButton.UseVisualStyleBackColor = true;
            this.UpdateWarehouseButton.Click += new System.EventHandler(this.UpdateWarehouseButton_Click);
            // 
            // DeleteWarehouseButton
            // 
            this.DeleteWarehouseButton.Location = new System.Drawing.Point(165, 3);
            this.DeleteWarehouseButton.Name = "DeleteWarehouseButton";
            this.DeleteWarehouseButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteWarehouseButton.TabIndex = 2;
            this.DeleteWarehouseButton.Text = "Delete";
            this.DeleteWarehouseButton.UseVisualStyleBackColor = true;
            this.DeleteWarehouseButton.Click += new System.EventHandler(this.DeleteWarehouseButton_Click);
            // 
            // Category
            // 
            this.Category.Controls.Add(this.tableLayoutPanel3);
            this.Category.Location = new System.Drawing.Point(4, 25);
            this.Category.Name = "Category";
            this.Category.Padding = new System.Windows.Forms.Padding(3);
            this.Category.Size = new System.Drawing.Size(909, 432);
            this.Category.TabIndex = 1;
            this.Category.Text = "Category";
            this.Category.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dataGridViewCategory, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dataGridViewCategoryDetail, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.10798F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.89202F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(903, 426);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // dataGridViewCategory
            // 
            this.dataGridViewCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCategory.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewCategory.Name = "dataGridViewCategory";
            this.dataGridViewCategory.Size = new System.Drawing.Size(445, 330);
            this.dataGridViewCategory.TabIndex = 0;
            // 
            // dataGridViewCategoryDetail
            // 
            this.dataGridViewCategoryDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategoryDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCategoryDetail.Location = new System.Drawing.Point(454, 3);
            this.dataGridViewCategoryDetail.Name = "dataGridViewCategoryDetail";
            this.dataGridViewCategoryDetail.Size = new System.Drawing.Size(446, 330);
            this.dataGridViewCategoryDetail.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.AddCategoryButton);
            this.flowLayoutPanel2.Controls.Add(this.UpdateCategoryButton);
            this.flowLayoutPanel2.Controls.Add(this.DeleteCategoryButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 339);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(445, 84);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // AddCategoryButton
            // 
            this.AddCategoryButton.Location = new System.Drawing.Point(3, 3);
            this.AddCategoryButton.Name = "AddCategoryButton";
            this.AddCategoryButton.Size = new System.Drawing.Size(75, 23);
            this.AddCategoryButton.TabIndex = 0;
            this.AddCategoryButton.Text = "Add";
            this.AddCategoryButton.UseVisualStyleBackColor = true;
            this.AddCategoryButton.Click += new System.EventHandler(this.AddCategoryButton_Click);
            // 
            // UpdateCategoryButton
            // 
            this.UpdateCategoryButton.Location = new System.Drawing.Point(84, 3);
            this.UpdateCategoryButton.Name = "UpdateCategoryButton";
            this.UpdateCategoryButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateCategoryButton.TabIndex = 1;
            this.UpdateCategoryButton.Text = "Update";
            this.UpdateCategoryButton.UseVisualStyleBackColor = true;
            this.UpdateCategoryButton.Click += new System.EventHandler(this.UpdateCategoryButton_Click);
            // 
            // DeleteCategoryButton
            // 
            this.DeleteCategoryButton.Location = new System.Drawing.Point(165, 3);
            this.DeleteCategoryButton.Name = "DeleteCategoryButton";
            this.DeleteCategoryButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteCategoryButton.TabIndex = 2;
            this.DeleteCategoryButton.Text = "Delete";
            this.DeleteCategoryButton.UseVisualStyleBackColor = true;
            this.DeleteCategoryButton.Click += new System.EventHandler(this.DeleteCategoryButton_Click);
            // 
            // Product
            // 
            this.Product.Controls.Add(this.tableLayoutPanel2);
            this.Product.Location = new System.Drawing.Point(4, 25);
            this.Product.Name = "Product";
            this.Product.Padding = new System.Windows.Forms.Padding(3);
            this.Product.Size = new System.Drawing.Size(909, 432);
            this.Product.TabIndex = 2;
            this.Product.Text = "Product";
            this.Product.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridViewProduct, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dataGridViewProductDetail, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.10798F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.89202F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(903, 426);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProduct.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.Size = new System.Drawing.Size(445, 330);
            this.dataGridViewProduct.TabIndex = 0;
            // 
            // dataGridViewProductDetail
            // 
            this.dataGridViewProductDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProductDetail.Location = new System.Drawing.Point(454, 3);
            this.dataGridViewProductDetail.Name = "dataGridViewProductDetail";
            this.dataGridViewProductDetail.Size = new System.Drawing.Size(446, 330);
            this.dataGridViewProductDetail.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.AddProductButton);
            this.flowLayoutPanel1.Controls.Add(this.UpdateProductButton);
            this.flowLayoutPanel1.Controls.Add(this.DeleteProductButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 339);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(445, 84);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // AddProductButton
            // 
            this.AddProductButton.Location = new System.Drawing.Point(3, 3);
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(75, 23);
            this.AddProductButton.TabIndex = 0;
            this.AddProductButton.Text = "Add";
            this.AddProductButton.UseVisualStyleBackColor = true;
            this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // UpdateProductButton
            // 
            this.UpdateProductButton.Location = new System.Drawing.Point(84, 3);
            this.UpdateProductButton.Name = "UpdateProductButton";
            this.UpdateProductButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateProductButton.TabIndex = 1;
            this.UpdateProductButton.Text = "Update";
            this.UpdateProductButton.UseVisualStyleBackColor = true;
            this.UpdateProductButton.Click += new System.EventHandler(this.UpdateProductButton_Click);
            // 
            // DeleteProductButton
            // 
            this.DeleteProductButton.Location = new System.Drawing.Point(165, 3);
            this.DeleteProductButton.Name = "DeleteProductButton";
            this.DeleteProductButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteProductButton.TabIndex = 2;
            this.DeleteProductButton.Text = "Delete";
            this.DeleteProductButton.UseVisualStyleBackColor = true;
            this.DeleteProductButton.Click += new System.EventHandler(this.DeleteProductButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(917, 461);
            this.Controls.Add(this.Tabs);
            this.Name = "MainForm";
            this.Text = "DesktopApp";
            this.Tabs.ResumeLayout(false);
            this.Warehouse.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouseDetail)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.Category.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategoryDetail)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.Product.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductDetail)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage Warehouse;
        private System.Windows.Forms.TabPage Category;
        private System.Windows.Forms.TabPage Product;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridViewProduct;
        private System.Windows.Forms.DataGridView dataGridViewProductDetail;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button AddProductButton;
        private System.Windows.Forms.Button UpdateProductButton;
        private System.Windows.Forms.Button DeleteProductButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dataGridViewCategory;
        private System.Windows.Forms.DataGridView dataGridViewCategoryDetail;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button AddCategoryButton;
        private System.Windows.Forms.Button UpdateCategoryButton;
        private System.Windows.Forms.Button DeleteCategoryButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridViewWarehouse;
        private System.Windows.Forms.DataGridView dataGridViewWarehouseDetail;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button AddWarehouseButton;
        private System.Windows.Forms.Button UpdateWarehouseButton;
        private System.Windows.Forms.Button DeleteWarehouseButton;
    }
}

