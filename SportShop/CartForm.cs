using Npgsql;
using SportShop.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace SportShop.Forms
{
    public partial class CartForm : Form
    {
        private int userId;
        private DataTable cartTable;
        private int userBonus;
        private Dictionary<int, int> cartState;

        public event EventHandler<Dictionary<int, int>> CartUpdated;

        public CartForm(int id, Dictionary<int, int> currentCart)
        {
            userId = id;
            cartState = new Dictionary<int, int>(currentCart);
            InitializeComponent();
            LoadUserBonus();
            LoadCart();

            btnPay.Click += BtnPay_Click;
            btnRemove.Click += BtnRemove_Click;
            checkBonus.CheckedChanged += (s, e) => UpdateTotal();
        }

        private void LoadUserBonus()
        {
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT bonus_points FROM users WHERE id=@uid", conn);
                cmd.Parameters.AddWithValue("@uid", userId);
                userBonus = Convert.ToInt32(cmd.ExecuteScalar());
                lblBonus.Text = $"({userBonus})";
            }
        }

        private void LoadCart()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("ID", typeof(int));
            cartTable.Columns.Add("Товар", typeof(string));
            cartTable.Columns.Add("Цена", typeof(decimal));
            cartTable.Columns.Add("Количество", typeof(int));
            cartTable.Columns.Add("Макс", typeof(int));

            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand(
                    @"SELECT c.product_id, p.name, p.price, c.quantity, p.stock 
                      FROM cart c JOIN products p ON c.product_id = p.id 
                      WHERE c.user_id=@uid", conn);
                cmd.Parameters.AddWithValue("@uid", userId);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int pid = reader.GetInt32(0);
                    int qty = reader.GetInt32(3);
                    cartState[pid] = qty; // синхронизация
                    cartTable.Rows.Add(
                        pid,
                        reader.GetString(1),
                        reader.GetDecimal(2),
                        qty,
                        reader.GetInt32(4));
                }
            }

            dgvCart.DataSource = cartTable;
            dgvCart.Columns["ID"].Visible = false;
            dgvCart.Columns["Макс"].Visible = false;
            dgvCart.Columns["Товар"].ReadOnly = true;
            dgvCart.Columns["Цена"].ReadOnly = true;

            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (DataRow row in cartTable.Rows)
                total += (decimal)row["Цена"] * Convert.ToInt32(row["Количество"]);

            int bonusToUse = checkBonus.Checked ? Math.Min(userBonus, (int)total) : 0;
            lblTotal.Text = $"Сумма: {total - bonusToUse} руб.";
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null)
            {
                int pid = Convert.ToInt32(dgvCart.CurrentRow.Cells["ID"].Value);

                using (var conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand(
                        "DELETE FROM cart WHERE user_id=@uid AND product_id=@pid", conn);
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@pid", pid);
                    cmd.ExecuteNonQuery();
                }

                // обновляем локальное состояние
                cartState.Remove(pid);

                LoadCart();

              
                CartUpdated?.Invoke(this, new Dictionary<int, int>(cartState));
            }
        }


        private void BtnPay_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0) return;

            int bonusToUse = checkBonus.Checked ? Math.Min(userBonus, (int)GetCartTotal()) : 0;
            decimal total = GetCartTotal() - bonusToUse;

            DataTable tableForWord = cartTable.Copy();

            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();

                int newBonus = (int)(total * 0.1m);
                var cmdBonus = new NpgsqlCommand(
                    "UPDATE users SET bonus_points = bonus_points - @used + @new WHERE id=@uid", conn);
                cmdBonus.Parameters.AddWithValue("@used", bonusToUse);
                cmdBonus.Parameters.AddWithValue("@new", newBonus);
                cmdBonus.Parameters.AddWithValue("@uid", userId);
                cmdBonus.ExecuteNonQuery();

                foreach (DataRow row in cartTable.Rows)
                {
                    int pid = Convert.ToInt32(row["ID"]);
                    int qty = Convert.ToInt32(row["Количество"]);
                    var cmd2 = new NpgsqlCommand("UPDATE products SET stock=stock-@qty WHERE id=@pid", conn);
                    cmd2.Parameters.AddWithValue("@qty", qty);
                    cmd2.Parameters.AddWithValue("@pid", pid);
                    cmd2.ExecuteNonQuery();
                }

                var cmd3 = new NpgsqlCommand("DELETE FROM cart WHERE user_id=@uid", conn);
                cmd3.Parameters.AddWithValue("@uid", userId);
                cmd3.ExecuteNonQuery();
            }

            cartState.Clear(); // очищаем словарь после оплаты
            LoadCart();
            LoadUserBonus();

            // создаем Word чек
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Directory.CreateDirectory(folder);
            string fileName = $"Check_{DateTime.Now:yyyyMMdd_HHmmss}.docx";
            string filePath = Path.Combine(folder, fileName);
            CreateWordCheck(filePath, tableForWord, bonusToUse, total);

            CartUpdated?.Invoke(this, cartState);
        }

        private decimal GetCartTotal()
        {
            decimal total = 0;
            foreach (DataRow row in cartTable.Rows)
                total += (decimal)row["Цена"] * Convert.ToInt32(row["Количество"]);
            return total;
        }

        private void CreateWordCheck(string filePath, DataTable tableForWord, int bonusDeduct, decimal total)
        {
            try
            {
                var wordApp = new Word.Application();
                var doc = wordApp.Documents.Add();

                string fullName = "", email = "", phone = "";
                using (var conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new NpgsqlCommand("SELECT full_name, email, phone FROM users WHERE id=@uid", conn);
                    cmd.Parameters.AddWithValue("@uid", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fullName = reader["full_name"].ToString();
                            email = reader["email"]?.ToString() ?? "";
                            phone = reader["phone"]?.ToString() ?? "";
                        }
                    }
                }

                Word.Paragraph para = doc.Paragraphs.Add();
                para.Range.Text = $"Чек онлайн-покупки\nДата: {DateTime.Now}\nНомер заказа: {new Random().Next(100000, 999999)}\n\n" +
                                  $"Покупатель: {fullName}\nEmail: {email}\nТелефон: {phone}\n\n";

                Word.Table table = doc.Tables.Add(para.Range, tableForWord.Rows.Count + 1, 4);
                table.Borders.Enable = 1;
                table.Cell(1, 1).Range.Text = "Товар";
                table.Cell(1, 2).Range.Text = "Цена";
                table.Cell(1, 3).Range.Text = "Количество";
                table.Cell(1, 4).Range.Text = "Сумма";

                int i = 2;
                foreach (DataRow row in tableForWord.Rows)
                {
                    table.Cell(i, 1).Range.Text = row["Товар"].ToString();
                    table.Cell(i, 2).Range.Text = row["Цена"].ToString();
                    table.Cell(i, 3).Range.Text = row["Количество"].ToString();
                    table.Cell(i, 4).Range.Text = ((decimal)row["Цена"] * Convert.ToInt32(row["Количество"])).ToString();
                    i++;
                }

                para = doc.Paragraphs.Add();
                para.Range.Text = $"\nСписано бонусов: {bonusDeduct}\nИтого к оплате: {total} руб.";

                doc.SaveAs2(filePath);
                wordApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании чека: " + ex.Message);
            }
        }
    }
}
