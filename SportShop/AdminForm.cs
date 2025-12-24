using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using SportShop.Db;

namespace SportShop.Forms
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();

            LoadUsers();
            LoadCategories();
            LoadProducts();

            btnAddUser.Click += BtnAddUser_Click;
            btnEditUser.Click += BtnEditUser_Click;
            btnDeleteUser.Click += BtnDeleteUser_Click;

            btnAddCategory.Click += BtnAddCategory_Click;
            btnEditCategory.Click += BtnEditCategory_Click;
            btnDeleteCategory.Click += BtnDeleteCategory_Click;

            btnAddProduct.Click += BtnAddProduct_Click;
            btnEditProduct.Click += BtnEditProduct_Click;
            btnDeleteProduct.Click += BtnDeleteProduct_Click;
        }

        // ---------- USERS ----------
        private void LoadUsers()
        {
            using (var c = DbConnection.GetConnection())
            {
                c.Open();
                // JOIN с roles, чтобы показывать название роли
                var da = new NpgsqlDataAdapter(
                    @"SELECT u.id, u.login, u.full_name, u.email, u.phone, u.bonus_points, r.name AS role 
              FROM users u
              LEFT JOIN roles r ON u.role_id = r.id
              ORDER BY u.id", c);

                var dt = new DataTable();
                da.Fill(dt);
                dgvUsers.DataSource = dt;

                // скрываем ID
                dgvUsers.Columns["id"].Visible = false;
            }
        }


        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            using (var f = new EditUserForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadUsers();
            }
        }

        private void BtnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            int id = (int)dgvUsers.SelectedRows[0].Cells["id"].Value;

            using (var f = new EditUserForm(id))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadUsers();
            }
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            int id = (int)dgvUsers.SelectedRows[0].Cells["id"].Value;

            var res = MessageBox.Show("Удалить пользователя?", "Удаление", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                using (var c = DbConnection.GetConnection())
                {
                    c.Open();
                    var cmd = new NpgsqlCommand("DELETE FROM users WHERE id=@id", c);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                LoadUsers();
            }
        }

        // ---------- CATEGORIES ----------
        private void LoadCategories()
        {
            using (var c = DbConnection.GetConnection())
            {
                c.Open();
                var da = new NpgsqlDataAdapter("SELECT id, name FROM sport_categories ORDER BY name", c);
                var dt = new DataTable();
                da.Fill(dt);
                dgvCategories.DataSource = dt;
                dgvCategories.Columns["id"].Visible = false;
            }
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            using (var f = new EditCategoryForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadCategories();
            }
        }

        private void BtnEditCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0) return;
            int id = (int)dgvCategories.SelectedRows[0].Cells["id"].Value;

            using (var f = new EditCategoryForm(id))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadCategories();
            }
        }

        private void BtnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0) return;
            int id = (int)dgvCategories.SelectedRows[0].Cells["id"].Value;

            var res = MessageBox.Show("Удалить категорию?", "Удаление", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                using (var c = DbConnection.GetConnection())
                {
                    c.Open();
                    var cmd = new NpgsqlCommand("DELETE FROM sport_categories WHERE id=@id", c);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                LoadCategories();
                LoadProducts(); // чтобы ComboBox обновился
            }
        }

        // ---------- PRODUCTS ----------
        private void LoadProducts()
        {
            using (var c = DbConnection.GetConnection())
            {
                c.Open();
                var da = new NpgsqlDataAdapter(
                    "SELECT p.id, p.name, p.price, p.stock, c.name AS category FROM products p LEFT JOIN sport_categories c ON p.category_id=c.id ORDER BY p.id", c);
                var dt = new DataTable();
                da.Fill(dt);
                dgvProducts.DataSource = dt;
                dgvProducts.Columns["id"].Visible = false;
            }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            using (var f = new EditProductForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadProducts();
            }
        }

        private void BtnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0) return;
            int id = (int)dgvProducts.SelectedRows[0].Cells["id"].Value;

            using (var f = new EditProductForm(id))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadProducts();
            }
        }

        private void BtnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0) return;
            int id = (int)dgvProducts.SelectedRows[0].Cells["id"].Value;

            var res = MessageBox.Show("Удалить товар?", "Удаление", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                using (var c = DbConnection.GetConnection())
                {
                    c.Open();
                    var cmd = new NpgsqlCommand("DELETE FROM products WHERE id=@id", c);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                LoadProducts();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }
    }
}
