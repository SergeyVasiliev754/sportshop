using System;
using System.Windows.Forms;

namespace SportShop.Controls
{
    public partial class ProductCard : UserControl
    {
        public event EventHandler<int> AddToCart; // передаем количество
        private int stock;
        private int productId;

        public int ProductId => productId;

        public ProductCard()
        {
            InitializeComponent();
            btnAdd.Click += BtnAdd_Click;
            cmbQty.SelectedIndexChanged += CmbQty_SelectedIndexChanged;
            cmbQty.Visible = false;
            lblAdded.Visible = false;
        }

        public void SetData(string name, decimal price, int stock, int id = 0)
        {
            lblName.Text = name;
            lblPrice.Text = $"{price:C}";
            lblStock.Text = $"В наличии: {stock}";
            this.stock = stock;
            this.productId = id;

            cmbQty.Items.Clear();
            for (int i = 1; i <= stock; i++)
                cmbQty.Items.Add(i);
            cmbQty.SelectedIndex = 0;

            btnAdd.Visible = true;
            cmbQty.Visible = false;
            lblAdded.Visible = false;
            btnAdd.Enabled = true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            cmbQty.Visible = true;
            lblAdded.Visible = true;
            lblAdded.Text = $"Добавлено в корзину: {cmbQty.SelectedItem} шт.";

            int qty = Convert.ToInt32(cmbQty.SelectedItem);
            AddToCart?.Invoke(this, qty);

            btnAdd.Enabled = false;
        }

        private void CmbQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAdded.Text = $"Добавлено в корзину: {cmbQty.SelectedItem} шт.";
            int qty = Convert.ToInt32(cmbQty.SelectedItem);
            AddToCart?.Invoke(this, qty);
        }

        public void SetAdded(int quantity)
        {
            cmbQty.Visible = true;
            lblAdded.Visible = true;
            lblAdded.Text = $"Добавлено в корзину: {quantity} шт.";
            cmbQty.SelectedItem = quantity;
            btnAdd.Enabled = false;
        }
    }
}
