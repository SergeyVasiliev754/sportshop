namespace SportShop.Forms
{
    partial class CashierForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.ListBox listProducts;
        private System.Windows.Forms.ListBox listBoxCart;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.Button btnFindClient;
        private System.Windows.Forms.CheckBox chkUseBonus;
        private System.Windows.Forms.Label lblBonus;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown nudQuantity;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierForm));
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.listProducts = new System.Windows.Forms.ListBox();
            this.listBoxCart = new System.Windows.Forms.ListBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.btnFindClient = new System.Windows.Forms.Button();
            this.chkUseBonus = new System.Windows.Forms.CheckBox();
            this.lblBonus = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.lblStock = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCategory
            // 
            this.cbCategory.Location = new System.Drawing.Point(20, 20);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(200, 24);
            this.cbCategory.TabIndex = 0;
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Location = new System.Drawing.Point(20, 50);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(200, 22);
            this.txtSearchProduct.TabIndex = 1;
            // 
            // listProducts
            // 
            this.listProducts.ItemHeight = 16;
            this.listProducts.Location = new System.Drawing.Point(20, 80);
            this.listProducts.Name = "listProducts";
            this.listProducts.Size = new System.Drawing.Size(250, 196);
            this.listProducts.TabIndex = 2;
            // 
            // listBoxCart
            // 
            this.listBoxCart.ItemHeight = 16;
            this.listBoxCart.Location = new System.Drawing.Point(380, 80);
            this.listBoxCart.Name = "listBoxCart";
            this.listBoxCart.Size = new System.Drawing.Size(250, 196);
            this.listBoxCart.TabIndex = 3;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddProduct.Location = new System.Drawing.Point(280, 120);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(94, 23);
            this.btnAddProduct.TabIndex = 4;
            this.btnAddProduct.Text = "Добавить →";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRemoveProduct.Location = new System.Drawing.Point(280, 160);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(94, 23);
            this.btnRemoveProduct.TabIndex = 5;
            this.btnRemoveProduct.Text = "Удалить";
            this.btnRemoveProduct.UseVisualStyleBackColor = false;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(20, 340);
            this.txtPhone.Mask = "+7 (000) 000-00-00";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(122, 22);
            this.txtPhone.TabIndex = 6;
            // 
            // btnFindClient
            // 
            this.btnFindClient.BackColor = System.Drawing.SystemColors.Menu;
            this.btnFindClient.Location = new System.Drawing.Point(170, 340);
            this.btnFindClient.Name = "btnFindClient";
            this.btnFindClient.Size = new System.Drawing.Size(100, 23);
            this.btnFindClient.TabIndex = 7;
            this.btnFindClient.Text = "Поиск клиента";
            this.btnFindClient.UseVisualStyleBackColor = false;
            // 
            // chkUseBonus
            // 
            this.chkUseBonus.Location = new System.Drawing.Point(20, 370);
            this.chkUseBonus.Name = "chkUseBonus";
            this.chkUseBonus.Size = new System.Drawing.Size(120, 24);
            this.chkUseBonus.TabIndex = 8;
            this.chkUseBonus.Text = "Списать бонусы";
            // 
            // lblBonus
            // 
            this.lblBonus.Location = new System.Drawing.Point(20, 400);
            this.lblBonus.Name = "lblBonus";
            this.lblBonus.Size = new System.Drawing.Size(150, 23);
            this.lblBonus.TabIndex = 9;
            this.lblBonus.Text = "Бонусы: 0";
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(380, 300);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(215, 23);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Сумма: 0 ₽";
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPay.Location = new System.Drawing.Point(380, 340);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(92, 23);
            this.btnPay.TabIndex = 11;
            this.btnPay.Text = "Оформить";
            this.btnPay.UseVisualStyleBackColor = false;
            // 
            // lblStock
            // 
            this.lblStock.Location = new System.Drawing.Point(20, 280);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(200, 23);
            this.lblStock.TabIndex = 12;
            this.lblStock.Text = "На складе: ";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(280, 92);
            this.nudQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(94, 22);
            this.nudQuantity.TabIndex = 13;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::SportShop.Properties.Resources.выход;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(557, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 57);
            this.button1.TabIndex = 14;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CashierForm
            // 
            this.BackgroundImage = global::SportShop.Properties.Resources.Рисунок2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(660, 440);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.txtSearchProduct);
            this.Controls.Add(this.listProducts);
            this.Controls.Add(this.listBoxCart);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnRemoveProduct);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnFindClient);
            this.Controls.Add(this.chkUseBonus);
            this.Controls.Add(this.lblBonus);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.nudQuantity);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CashierForm";
            this.Text = "Касса";
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
