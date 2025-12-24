using Npgsql;
using SportShop.Db;
using System;
using System.Windows.Forms;

namespace SportShop.Forms
{
    public partial class ChangePhoneForm : Form
    {
        private int userId;

        public ChangePhoneForm(int id)
        {
            userId = id;
            InitializeComponent();
            btnConfirm.Click += BtnConfirm_Click;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT password FROM users WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", userId);
                string currentPassword = cmd.ExecuteScalar().ToString();
                if (txtPassword.Text != currentPassword)
                {
                    MessageBox.Show("Неверный пароль!");
                    return;
                }

                cmd = new NpgsqlCommand("UPDATE users SET phone=@phone WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Телефон обновлён!");
            this.Close();
        }
    }
}
