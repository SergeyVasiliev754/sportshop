using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Npgsql;
using SportShop.Db;

namespace SportShop.Forms
{
    public partial class RegisterForm : Form
    {
        public int ClientId { get; private set; } = -1;

        private string _phone;

        public RegisterForm() : this("") { }

        public RegisterForm(string phone)
        {
            _phone = phone;
            InitializeComponent();
            txtPhone.Text = _phone;
            btnRegister.Click += BtnRegister_Click;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtFio.Text))
            {
                MessageBox.Show("Заполните обязательные поля!");
                return;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Неверный email");
                return;
            }

            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand(
                    @"INSERT INTO users
                      (login,password,full_name,email,phone,role_id,bonus_points)
                      VALUES(@l,@p,@f,@e,@ph,3,0)
                      RETURNING id;", conn);

                cmd.Parameters.AddWithValue("@l", txtLogin.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                cmd.Parameters.AddWithValue("@f", txtFio.Text);
                cmd.Parameters.AddWithValue("@e", txtEmail.Text);
                cmd.Parameters.AddWithValue("@ph", txtPhone.Text);

                ClientId = (int)cmd.ExecuteScalar();
            }

            MessageBox.Show("Регистрация успешна");
            this.Close();
        }
    }
}
