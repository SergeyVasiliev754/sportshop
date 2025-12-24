using Npgsql;
using SportShop.Controls;
using SportShop.Db;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SportShop.Forms
{
    public partial class ClientMainForm : Form
    {
        private int userId;

        // хранит productId -> количество в корзине
        private Dictionary<int, int> cartState = new Dictionary<int, int>();

        public ClientMainForm(int id)
        {
            userId = id;
            InitializeComponent();

            btnCart.Click += BtnCart_Click;
            btnProfile.Click += BtnProfile_Click;
            cmbCategory.SelectedIndexChanged += (s, e) => LoadProducts();
            cmbSortPrice.SelectedIndexChanged += (s, e) => LoadProducts();

            LoadCategories();
            LoadProducts();
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            new ProfileForm(userId).ShowDialog();
        }

        private void BtnCart_Click(object sender, EventArgs e)
        {
            var cartForm = new CartForm(userId, cartState);
            cartForm.CartUpdated += CartForm_CartUpdated; // подписка на событие изменения корзины
            cartForm.ShowDialog();
        }

        private void CartForm_CartUpdated(object sender, Dictionary<int, int> updatedCart)
        {
            // обновляем словарь
            cartState = new Dictionary<int, int>(updatedCart);
            LoadProducts(); // обновляем карточки
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Все");
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT name FROM sport_categories ORDER BY name", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbCategory.Items.Add(reader.GetString(0));
                }
            }
            cmbCategory.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            LoadCartStateFromDb();
            tableLayoutPanelProducts.SuspendLayout();
            tableLayoutPanelProducts.Controls.Clear();
            tableLayoutPanelProducts.RowStyles.Clear();
            tableLayoutPanelProducts.RowCount = 0;
            tableLayoutPanelProducts.ColumnCount = 3;
            tableLayoutPanelProducts.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;

            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql =
                    "SELECT p.id, p.name, p.price, p.stock, s.name " +
                    "FROM products p " +
                    "JOIN sport_categories s ON p.category_id = s.id " +
                    "WHERE p.stock > 0";

                if (cmbCategory.SelectedIndex > 0)
                    sql += " AND s.name = @cat";

                sql += " ORDER BY p.price " + (cmbSortPrice.SelectedIndex == 1 ? "DESC" : "ASC");

                var cmd = new NpgsqlCommand(sql, conn);
                if (cmbCategory.SelectedIndex > 0)
                    cmd.Parameters.AddWithValue("@cat", cmbCategory.SelectedItem.ToString());

                var reader = cmd.ExecuteReader();
                int row = 0, col = 0;

                while (reader.Read())
                {
                    int pid = reader.GetInt32(0);
                    int stock = reader.GetInt32(3);
                    var card = new ProductCard();
                    card.SetData(reader.GetString(1), reader.GetDecimal(2), stock, pid);

                    // если товар уже в словаре, показываем надпись и счётчик
                    if (cartState.ContainsKey(pid))
                        card.SetAdded(cartState[pid]);

                    card.AddToCart += (s, qty) => AddToCart(pid, qty);

                    if (col == 0)
                    {
                        tableLayoutPanelProducts.RowCount++;
                        tableLayoutPanelProducts.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }

                    tableLayoutPanelProducts.Controls.Add(card, col, row);
                    col++;
                    if (col == 3)
                    {
                        col = 0;
                        row++;
                    }
                }
            }

            tableLayoutPanelProducts.ResumeLayout();
        }
        private void LoadCartStateFromDb()
        {
            cartState.Clear();
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT product_id, quantity FROM cart WHERE user_id=@uid", conn);
                cmd.Parameters.AddWithValue("@uid", userId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int pid = reader.GetInt32(0);
                        int qty = reader.GetInt32(1);
                        cartState[pid] = qty;
                    }
                }
            }
        }

        private void AddToCart(int productId, int quantity)
        {
            // сохраняем в словаре
            if (cartState.ContainsKey(productId))
                cartState[productId] = quantity;
            else
                cartState.Add(productId, quantity);

            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand(
                    @"INSERT INTO cart(user_id, product_id, quantity)
                      VALUES(@u, @p, @q)
                      ON CONFLICT (user_id, product_id)
                      DO UPDATE SET quantity = @q", conn);

                cmd.Parameters.AddWithValue("@u", userId);
                cmd.Parameters.AddWithValue("@p", productId);
                cmd.Parameters.AddWithValue("@q", quantity);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }
    }
}
