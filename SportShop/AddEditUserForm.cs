using Npgsql;
using SportShop.Db;
using System;
using System.Windows.Forms;

namespace SportShop.Forms
{
    public partial class AddEditUserForm : Form
    {
        public AddEditUserForm()
        {
            InitializeComponent();
            cbRole.Items.AddRange(new string[] { "admin", "cashier", "client" });
            cbRole.SelectedIndex = 0;

            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string name = txtFullName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string role = cbRole.Text;

            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand(
                    "INSERT INTO users (full_name,email,phone,role) VALUES (@n,@e,@p,@r)", conn);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@p", phone);
                cmd.Parameters.AddWithValue("@r", role);
                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
