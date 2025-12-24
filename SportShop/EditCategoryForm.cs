using System;
using System.Windows.Forms;
using System.Xml.Linq;
using Npgsql;
using SportShop.Db;

namespace SportShop.Forms
{
    public partial class EditCategoryForm : Form
    {
        private int categoryId = -1;

        public EditCategoryForm(int id = -1, string name = "")
        {
            InitializeComponent();
            categoryId = id;
            txtName.Text = name;
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Введите название категории");
                return;
            }

            NpgsqlConnection conn = DbConnection.GetConnection();
            conn.Open();

            if (categoryId == -1)
            {
                NpgsqlCommand cmd = new NpgsqlCommand(
                    "INSERT INTO sport_categories (name) VALUES (@n)", conn);
                cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                cmd.ExecuteNonQuery();
            }
            else
            {
                NpgsqlCommand cmd = new NpgsqlCommand(
                    "UPDATE sport_categories SET name=@n WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@id", categoryId);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
