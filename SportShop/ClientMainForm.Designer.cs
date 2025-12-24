namespace SportShop.Forms
{
    partial class ClientMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProducts;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbSortPrice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientMainForm));
            this.tableLayoutPanelProducts = new System.Windows.Forms.TableLayoutPanel();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbSortPrice = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tableLayoutPanelProducts
            // 
            this.tableLayoutPanelProducts.AutoScroll = true;
            this.tableLayoutPanelProducts.ColumnCount = 3;
            this.tableLayoutPanelProducts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelProducts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelProducts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanelProducts.Location = new System.Drawing.Point(12, 100);
            this.tableLayoutPanelProducts.Name = "tableLayoutPanelProducts";
            this.tableLayoutPanelProducts.RowCount = 1;
            this.tableLayoutPanelProducts.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelProducts.Size = new System.Drawing.Size(760, 340);
            this.tableLayoutPanelProducts.TabIndex = 5;
            // 
            // btnCart
            // 
            this.btnCart.BackgroundImage = global::SportShop.Properties.Resources.korz;
            this.btnCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCart.Location = new System.Drawing.Point(673, 42);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(69, 47);
            this.btnCart.TabIndex = 4;
            // 
            // btnProfile
            // 
            this.btnProfile.BackgroundImage = global::SportShop.Properties.Resources._2bc3f725c348eb9f57cfe87bbf3b143e;
            this.btnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProfile.Location = new System.Drawing.Point(584, 42);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(69, 47);
            this.btnProfile.TabIndex = 3;
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::SportShop.Properties.Resources.выход;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.Location = new System.Drawing.Point(12, 42);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(68, 48);
            this.btnBack.TabIndex = 2;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(12, 12);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(180, 24);
            this.cmbCategory.TabIndex = 0;
            // 
            // cmbSortPrice
            // 
            this.cmbSortPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortPrice.Items.AddRange(new object[] {
            "По возрастанию цены",
            "По убыванию цены"});
            this.cmbSortPrice.Location = new System.Drawing.Point(200, 12);
            this.cmbSortPrice.Name = "cmbSortPrice";
            this.cmbSortPrice.Size = new System.Drawing.Size(120, 24);
            this.cmbSortPrice.TabIndex = 1;
            // 
            // ClientMainForm
            // 
            this.BackgroundImage = global::SportShop.Properties.Resources.Рисунок1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbSortPrice);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnCart);
            this.Controls.Add(this.tableLayoutPanelProducts);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientMainForm";
            this.Text = "Магазин";
            this.ResumeLayout(false);

        }
    }
}
