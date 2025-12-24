using Npgsql;
using SportShop.Db;
using System;
using System.Windows.Forms;

namespace SportShop.Forms
{
    public partial class ProfileForm : Form
    {
        private int userId;

        public ProfileForm(int id)
        {
            userId = id;
            InitializeComponent();
            btnChangePhone.Click += BtnChangePhone_Click;
            LoadProfile();
        }

        private void LoadProfile()
        {
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT full_name,email,phone,bonus_points FROM users WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", userId);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblFullName.Text = $"ФИО: {reader.GetString(0)}";
                    lblEmail.Text = $"Email: {(reader.IsDBNull(1) ? "" : reader.GetString(1))}";
                    lblPhone.Text = $"Телефон: {(reader.IsDBNull(2) ? "" : reader.GetString(2))}";
                    lblBonus.Text = $"Бонусы: {reader.GetInt32(3)}";
                }
            }
        }

        private void BtnChangePhone_Click(object sender, EventArgs e)
        {
            using (var changeForm = new ChangePhoneForm(userId))
            {
                changeForm.ShowDialog();
            }
            LoadProfile(); // обновляем данные после закрытия окна смены номера
        }
    }
}
