namespace SportShop.Controls
{
    partial class ProductCard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbQty;
        private System.Windows.Forms.Label lblAdded;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbQty = new System.Windows.Forms.ComboBox();
            this.lblAdded = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(10, 10);
            this.lblName.Size = new System.Drawing.Size(180, 30);
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(10, 45);
            this.lblPrice.Size = new System.Drawing.Size(100, 15);
            // 
            // lblStock
            // 
            this.lblStock.Location = new System.Drawing.Point(10, 65);
            this.lblStock.Size = new System.Drawing.Size(150, 15);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 90);
            this.btnAdd.Size = new System.Drawing.Size(160, 25);
            this.btnAdd.Text = "В корзину";
            // 
            // lblAdded
            // 
            this.lblAdded.Location = new System.Drawing.Point(10, 120);
            this.lblAdded.Size = new System.Drawing.Size(150, 15);
            this.lblAdded.Text = "Добавлено в корзину";
            this.lblAdded.ForeColor = System.Drawing.Color.Green;
            this.lblAdded.Visible = false;
            // 
            // cmbQty
            // 
            this.cmbQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQty.Location = new System.Drawing.Point(10, 140);
            this.cmbQty.Size = new System.Drawing.Size(60, 23);
            this.cmbQty.Visible = false;
            // 
            // ProductCard
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblAdded);
            this.Controls.Add(this.cmbQty);
            this.Size = new System.Drawing.Size(180, 175);
            this.ResumeLayout(false);
        }
    }
}
