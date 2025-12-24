using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Xml.Linq;
using Npgsql;
using SportShop.Db;

namespace SportShop.Forms
{
    public partial class EditProductForm : Form
    {
        private int productId = -1;

        public EditProductForm(int id = -1, string name = "", decimal price = 0, int stock = 0, int categoryId = -1)
        {
            InitializeComponent();
            productId = id;
            txtName.Text = name;
            nudPrice.Value = price;
            nudStock.Value = stock;

            LoadCategories();
            if (categoryId != -1)
                cbCategory.SelectedValue = categoryId;

            btnSave.Click += BtnSave_Click;
        }

        private void LoadCategories()
        {
            NpgsqlConnection conn = DbConnection.GetConnection();
            conn.Open();
            System.Data.DataTable dt = new System.Data.DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT id, name FROM sport_categories ORDER BY name", conn);
            da.Fill(dt);
            cbCategory.DataSource = dt;
            cbCategory.DisplayMember = "name";
            cbCategory.ValueMember = "id";
            conn.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Введите название продукта");
                return;
            }

            int categoryId = (int)cbCategory.SelectedValue;
            NpgsqlConnection conn = DbConnection.GetConnection();
            conn.Open();

            if (productId == -1) // Insert
            {
                NpgsqlCommand cmd = new NpgsqlCommand(
                    "INSERT INTO products (name, price, stock, category_id) VALUES (@n, @p, @s, @c)", conn);
                cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@p", nudPrice.Value);
                cmd.Parameters.AddWithValue("@s", (int)nudStock.Value);
                cmd.Parameters.AddWithValue("@c", categoryId);
                cmd.ExecuteNonQuery();
            }
            else // Update
            {
                NpgsqlCommand cmd = new NpgsqlCommand(
                    "UPDATE products SET name=@n, price=@p, stock=@s, category_id=@c WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@p", nudPrice.Value);
                cmd.Parameters.AddWithValue("@s", (int)nudStock.Value);
                cmd.Parameters.AddWithValue("@c", categoryId);
                cmd.Parameters.AddWithValue("@id", productId);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
