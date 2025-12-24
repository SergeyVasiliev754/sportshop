using System;
using System.Windows.Forms;
using Npgsql;
using SportShop.Db;

namespace SportShop.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

              
        private void BtnRegister_Click_1(object sender, EventArgs e)
        {
            // Открываем форму регистрации без телефона
            using (var regForm = new RegisterForm())
            {
                regForm.ShowDialog();
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT u.id, u.full_name, r.name AS role_name
                               FROM users u
                               JOIN roles r ON u.role_id = r.id
                               WHERE u.login=@login AND u.password=@password";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@login", txtLogin.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = Convert.ToInt32(reader["id"]);
                            string role = reader["role_name"].ToString();

                            if (role == "Администратор")
                                new AdminForm().Show();
                            else if (role == "Кассир")
                                new CashierForm(userId).Show();
                            else
                                new ClientMainForm(userId).Show();

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль");
                        }
                    }
                }
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
