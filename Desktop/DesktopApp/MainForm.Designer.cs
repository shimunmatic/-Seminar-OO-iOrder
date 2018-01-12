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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DeleteButton1 = new System.Windows.Forms.Button();
            this.UpdateButton1 = new System.Windows.Forms.Button();
            this.AddButton1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.Category = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Product = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.DeleteButton3 = new System.Windows.Forms.Button();
            this.UpdateButton3 = new System.Windows.Forms.Button();
            this.AddButton3 = new System.Windows.Forms.Button();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.AddButton2 = new System.Windows.Forms.Button();
            this.UpdateButton2 = new System.Windows.Forms.Button();
            this.DeleteButton2 = new System.Windows.Forms.Button();
            this.Tabs.SuspendLayout();
            this.Warehouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.Category.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.Product.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.Tabs.Controls.Add(this.Warehouse);
            this.Tabs.Controls.Add(this.Category);
            this.Tabs.Controls.Add(this.Product);
            this.Tabs.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Tabs.Location = new System.Drawing.Point(22, 12);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(681, 305);
            this.Tabs.TabIndex = 0;
            this.Tabs.Tag = "";
            // 
            // Warehouse
            // 
            this.Warehouse.Controls.Add(this.splitContainer1);
            this.Warehouse.Location = new System.Drawing.Point(4, 25);
            this.Warehouse.Name = "Warehouse";
            this.Warehouse.Padding = new System.Windows.Forms.Padding(3);
            this.Warehouse.Size = new System.Drawing.Size(673, 276);
            this.Warehouse.TabIndex = 0;
            this.Warehouse.Text = "Warehouse";
            this.Warehouse.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DeleteButton1);
            this.splitContainer1.Panel1.Controls.Add(this.UpdateButton1);
            this.splitContainer1.Panel1.Controls.Add(this.AddButton1);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView4);
            this.splitContainer1.Size = new System.Drawing.Size(673, 279);
            this.splitContainer1.SplitterDistance = 301;
            this.splitContainer1.TabIndex = 1;
            // 
            // DeleteButton1
            // 
            this.DeleteButton1.Location = new System.Drawing.Point(196, 224);
            this.DeleteButton1.Name = "DeleteButton1";
            this.DeleteButton1.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton1.TabIndex = 3;
            this.DeleteButton1.Text = "Delete";
            this.DeleteButton1.UseVisualStyleBackColor = true;
            this.DeleteButton1.Click += new System.EventHandler(this.DeleteButton1_Click);
            // 
            // UpdateButton1
            // 
            this.UpdateButton1.Location = new System.Drawing.Point(115, 224);
            this.UpdateButton1.Name = "UpdateButton1";
            this.UpdateButton1.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton1.TabIndex = 2;
            this.UpdateButton1.Text = "Update";
            this.UpdateButton1.UseVisualStyleBackColor = true;
            this.UpdateButton1.Click += new System.EventHandler(this.UpdateButton1_Click);
            // 
            // AddButton1
            // 
            this.AddButton1.Location = new System.Drawing.Point(34, 224);
            this.AddButton1.Name = "AddButton1";
            this.AddButton1.Size = new System.Drawing.Size(75, 23);
            this.AddButton1.TabIndex = 1;
            this.AddButton1.Text = "Add";
            this.AddButton1.UseVisualStyleBackColor = true;
            this.AddButton1.Click += new System.EventHandler(this.AddButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(291, 211);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(3, 7);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(436, 211);
            this.dataGridView4.TabIndex = 0;
            // 
            // Category
            // 
            this.Category.Controls.Add(this.splitContainer2);
            this.Category.Location = new System.Drawing.Point(4, 25);
            this.Category.Name = "Category";
            this.Category.Padding = new System.Windows.Forms.Padding(3);
            this.Category.Size = new System.Drawing.Size(673, 276);
            this.Category.TabIndex = 1;
            this.Category.Text = "Category";
            this.Category.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.DeleteButton2);
            this.splitContainer2.Panel1.Controls.Add(this.UpdateButton2);
            this.splitContainer2.Panel1.Controls.Add(this.AddButton2);
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView3);
            this.splitContainer2.Size = new System.Drawing.Size(667, 270);
            this.splitContainer2.SplitterDistance = 347;
            this.splitContainer2.TabIndex = 0;
            // 
            // Product
            // 
            this.Product.Controls.Add(this.splitContainer3);
            this.Product.Location = new System.Drawing.Point(4, 25);
            this.Product.Name = "Product";
            this.Product.Padding = new System.Windows.Forms.Padding(3);
            this.Product.Size = new System.Drawing.Size(673, 276);
            this.Product.TabIndex = 2;
            this.Product.Text = "Product";
            this.Product.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.DeleteButton3);
            this.splitContainer3.Panel1.Controls.Add(this.UpdateButton3);
            this.splitContainer3.Panel1.Controls.Add(this.AddButton3);
            this.splitContainer3.Panel1.Controls.Add(this.dataGridView5);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataGridView6);
            this.splitContainer3.Size = new System.Drawing.Size(667, 270);
            this.splitContainer3.SplitterDistance = 331;
            this.splitContainer3.TabIndex = 0;
            // 
            // DeleteButton3
            // 
            this.DeleteButton3.Location = new System.Drawing.Point(213, 215);
            this.DeleteButton3.Name = "DeleteButton3";
            this.DeleteButton3.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton3.TabIndex = 3;
            this.DeleteButton3.Text = "Delete";
            this.DeleteButton3.UseVisualStyleBackColor = true;
            this.DeleteButton3.Click += new System.EventHandler(this.DeleteButton3_Click);
            // 
            // UpdateButton3
            // 
            this.UpdateButton3.Location = new System.Drawing.Point(132, 215);
            this.UpdateButton3.Name = "UpdateButton3";
            this.UpdateButton3.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton3.TabIndex = 2;
            this.UpdateButton3.Text = "Upadate";
            this.UpdateButton3.UseVisualStyleBackColor = true;
            this.UpdateButton3.Click += new System.EventHandler(this.UpdateButton3_Click);
            // 
            // AddButton3
            // 
            this.AddButton3.Location = new System.Drawing.Point(51, 215);
            this.AddButton3.Name = "AddButton3";
            this.AddButton3.Size = new System.Drawing.Size(75, 23);
            this.AddButton3.TabIndex = 1;
            this.AddButton3.Text = "Add";
            this.AddButton3.UseVisualStyleBackColor = true;
            this.AddButton3.Click += new System.EventHandler(this.AddButton3_Click);
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(3, 3);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(325, 206);
            this.dataGridView5.TabIndex = 0;
            // 
            // dataGridView6
            // 
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Location = new System.Drawing.Point(3, 3);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.Size = new System.Drawing.Size(326, 206);
            this.dataGridView6.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(341, 210);
            this.dataGridView2.TabIndex = 0;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(-1, 3);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(314, 210);
            this.dataGridView3.TabIndex = 0;
            // 
            // AddButton2
            // 
            this.AddButton2.Location = new System.Drawing.Point(51, 219);
            this.AddButton2.Name = "AddButton2";
            this.AddButton2.Size = new System.Drawing.Size(75, 23);
            this.AddButton2.TabIndex = 1;
            this.AddButton2.Text = "Add";
            this.AddButton2.UseVisualStyleBackColor = true;
            this.AddButton2.Click += new System.EventHandler(this.AddButton2_Click);
            // 
            // UpdateButton2
            // 
            this.UpdateButton2.Location = new System.Drawing.Point(133, 219);
            this.UpdateButton2.Name = "UpdateButton2";
            this.UpdateButton2.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton2.TabIndex = 2;
            this.UpdateButton2.Text = "Update";
            this.UpdateButton2.UseVisualStyleBackColor = true;
            this.UpdateButton2.Click += new System.EventHandler(this.UpdateButton2_Click);
            // 
            // DeleteButton2
            // 
            this.DeleteButton2.Location = new System.Drawing.Point(215, 219);
            this.DeleteButton2.Name = "DeleteButton2";
            this.DeleteButton2.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton2.TabIndex = 3;
            this.DeleteButton2.Text = "Delete";
            this.DeleteButton2.UseVisualStyleBackColor = true;
            this.DeleteButton2.Click += new System.EventHandler(this.DeleteButton2_Click);
            // 
            // DesktopApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 348);
            this.Controls.Add(this.Tabs);
            this.Name = "DesktopApp";
            this.Text = "DesktopApp";
            this.Tabs.ResumeLayout(false);
            this.Warehouse.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.Category.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.Product.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage Warehouse;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage Category;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.TabPage Product;
        private System.Windows.Forms.Button DeleteButton1;
        private System.Windows.Forms.Button UpdateButton1;
        private System.Windows.Forms.Button AddButton1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button DeleteButton3;
        private System.Windows.Forms.Button UpdateButton3;
        private System.Windows.Forms.Button AddButton3;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.Button DeleteButton2;
        private System.Windows.Forms.Button UpdateButton2;
        private System.Windows.Forms.Button AddButton2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
    }
}

