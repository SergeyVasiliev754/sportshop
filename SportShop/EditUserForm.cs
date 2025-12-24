using System;
using System.Windows.Forms;
using Npgsql;
using SportShop.Db;

namespace SportShop.Forms
{
    public partial class EditUserForm : Form
    {
        private int userId = -1;

        public EditUserForm(int id = -1, string fullName = "", string email = "", string phone = "", string role = "")
        {
            InitializeComponent();
            userId = id;
            txtFullName.Text = fullName;
            txtEmail.Text = email;
            txtPhone.Text = phone;

            cbRole.Items.AddRange(new string[] { "администратор", "кассир", "клиент" });
            if (role != "") cbRole.SelectedItem = role;

            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text.Trim() == "" || txtPhone.MaskFull == false || cbRole.SelectedItem == null)
            {
                MessageBox.Show("Заполните все обязательные поля!");
                return;
            }

            NpgsqlConnection conn = DbConnection.GetConnection();
            conn.Open();

            if (userId == -1)
            {
                NpgsqlCommand cmd = new NpgsqlCommand(
                    "INSERT INTO users (full_name, email, phone, role) VALUES (@f, @e, @p, @r)", conn);
                cmd.Parameters.AddWithValue("@f", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@e", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                cmd.Parameters.AddWithValue("@r", cbRole.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
            }
            else
            {
                NpgsqlCommand cmd = new NpgsqlCommand(
                    "UPDATE users SET full_name=@f, email=@e, phone=@p, role=@r WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@f", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@e", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                cmd.Parameters.AddWithValue("@r", cbRole.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
