namespace SportShop.Forms
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.TabPage tabProducts;

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.DataGridView dgvProducts;

        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnDeleteUser;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tabCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabUsers);
            this.tabControl.Controls.Add(this.tabCategories);
            this.tabControl.Controls.Add(this.tabProducts);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(680, 484);
            this.tabControl.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.button1);
            this.tabUsers.Controls.Add(this.dgvUsers);
            this.tabUsers.Controls.Add(this.btnAddUser);
            this.tabUsers.Controls.Add(this.btnEditUser);
            this.tabUsers.Controls.Add(this.btnDeleteUser);
            this.tabUsers.Location = new System.Drawing.Point(4, 25);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(672, 455);
            this.tabUsers.TabIndex = 0;
            this.tabUsers.Text = "Пользователи";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::SportShop.Properties.Resources.выход;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(564, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 64);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeight = 29;
            this.dgvUsers.Location = new System.Drawing.Point(6, 6);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(650, 350);
            this.dgvUsers.TabIndex = 0;
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackgroundImage = global::SportShop.Properties.Resources._new;
            this.btnAddUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddUser.Location = new System.Drawing.Point(11, 360);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(72, 50);
            this.btnAddUser.TabIndex = 1;
            // 
            // btnEditUser
            // 
            this.btnEditUser.BackgroundImage = global::SportShop.Properties.Resources.редакт;
            this.btnEditUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditUser.Location = new System.Drawing.Point(89, 360);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(74, 50);
            this.btnEditUser.TabIndex = 2;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackgroundImage = global::SportShop.Properties.Resources.del;
            this.btnDeleteUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteUser.Location = new System.Drawing.Point(169, 360);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(61, 50);
            this.btnDeleteUser.TabIndex = 3;
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.button2);
            this.tabCategories.Controls.Add(this.btnAddCategory);
            this.tabCategories.Controls.Add(this.btnEditCategory);
            this.tabCategories.Controls.Add(this.btnDeleteCategory);
            this.tabCategories.Controls.Add(this.dgvCategories);
            this.tabCategories.Location = new System.Drawing.Point(4, 25);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Size = new System.Drawing.Size(672, 455);
            this.tabCategories.TabIndex = 1;
            this.tabCategories.Text = "Категории";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::SportShop.Properties.Resources.выход;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(560, 385);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 64);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackgroundImage = global::SportShop.Properties.Resources._new;
            this.btnAddCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddCategory.Location = new System.Drawing.Point(7, 362);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(72, 50);
            this.btnAddCategory.TabIndex = 5;
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.BackgroundImage = global::SportShop.Properties.Resources.редакт;
            this.btnEditCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditCategory.Location = new System.Drawing.Point(85, 362);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(74, 50);
            this.btnEditCategory.TabIndex = 6;
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.BackgroundImage = global::SportShop.Properties.Resources.del;
            this.btnDeleteCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteCategory.Location = new System.Drawing.Point(165, 362);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(61, 50);
            this.btnDeleteCategory.TabIndex = 7;
            // 
            // dgvCategories
            // 
            this.dgvCategories.ColumnHeadersHeight = 29;
            this.dgvCategories.Location = new System.Drawing.Point(6, 6);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersWidth = 51;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(650, 350);
            this.dgvCategories.TabIndex = 0;
            // 
            // tabProducts
            // 
            this.tabProducts.Controls.Add(this.button6);
            this.tabProducts.Controls.Add(this.btnAddProduct);
            this.tabProducts.Controls.Add(this.btnEditProduct);
            this.tabProducts.Controls.Add(this.btnDeleteProduct);
            this.tabProducts.Controls.Add(this.dgvProducts);
            this.tabProducts.Location = new System.Drawing.Point(4, 25);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Size = new System.Drawing.Size(672, 455);
            this.tabProducts.TabIndex = 2;
            this.tabProducts.Text = "Товары";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.BackgroundImage = global::SportShop.Properties.Resources.выход;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.Location = new System.Drawing.Point(568, 385);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(92, 64);
            this.button6.TabIndex = 8;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackgroundImage = global::SportShop.Properties.Resources._new;
            this.btnAddProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddProduct.Location = new System.Drawing.Point(15, 362);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(72, 50);
            this.btnAddProduct.TabIndex = 5;
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.BackgroundImage = global::SportShop.Properties.Resources.редакт;
            this.btnEditProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditProduct.Location = new System.Drawing.Point(93, 362);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(74, 50);
            this.btnEditProduct.TabIndex = 6;
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.BackgroundImage = global::SportShop.Properties.Resources.del;
            this.btnDeleteProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteProduct.Location = new System.Drawing.Point(173, 362);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(61, 50);
            this.btnDeleteProduct.TabIndex = 7;
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeight = 29;
            this.dgvProducts.Location = new System.Drawing.Point(6, 6);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(650, 350);
            this.dgvProducts.TabIndex = 0;
            // 
            // AdminForm
            // 
            this.ClientSize = new System.Drawing.Size(680, 484);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminForm";
            this.Text = "Админ панель";
            this.tabControl.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tabCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.tabProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button button1;
    }
}
