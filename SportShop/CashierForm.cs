using Npgsql;
using SportShop.Db;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace SportShop.Forms
{
    public partial class CashierForm : Form
    {
        private int cashierId;
        private string cashierFio;

        private int clientId = -1;
        private string clientFio = "";
        private string clientEmail = "";
        private string clientPhone = "";
        private int clientBonus = 0;

        private decimal totalSum = 0;

        // Хранение количества каждого товара в корзине
        private Dictionary<string, int> cartQuantity = new Dictionary<string, int>();

        // Хранение количества на складе
        private Dictionary<string, int> stockQuantity = new Dictionary<string, int>();

        public CashierForm(int userId)
        {
            cashierId = userId;
            InitializeComponent();

            LoadCashier();
            LoadCategories();
            LoadProducts();

            cbCategory.SelectedIndexChanged += (s, e) => LoadProducts();
            txtSearchProduct.TextChanged += (s, e) => LoadProducts();
            listProducts.SelectedIndexChanged += ListProducts_SelectedIndexChanged;

            btnAddProduct.Click += BtnAddProduct_Click;
            btnRemoveProduct.Click += BtnRemoveProduct_Click;
            btnFindClient.Click += BtnFindClient_Click;
            chkUseBonus.CheckedChanged += (s, e) => UpdateSum();
            btnPay.Click += BtnPay_Click;
        }

        // ---------- КАССИР ----------
        private void LoadCashier()
        {
            using (var c = DbConnection.GetConnection())
            {
                c.Open();
                var cmd = new NpgsqlCommand(
                    "SELECT full_name FROM users WHERE id=@id", c);
                cmd.Parameters.AddWithValue("@id", cashierId);
                cashierFio = cmd.ExecuteScalar()?.ToString() ?? "";
            }
        }

        // ---------- КАТЕГОРИИ ----------
        private void LoadCategories()
        {
            cbCategory.Items.Clear();
            cbCategory.Items.Add("Все");

            using (var c = DbConnection.GetConnection())
            {
                c.Open();
                var cmd = new NpgsqlCommand(
                    "SELECT name FROM sport_categories ORDER BY name", c);
                var r = cmd.ExecuteReader();
                while (r.Read())
                    cbCategory.Items.Add(r.GetString(0));
                r.Close();
            }
            cbCategory.SelectedIndex = 0;
        }

        // ---------- ТОВАРЫ ----------
        private void LoadProducts()
        {
            listProducts.Items.Clear();
            stockQuantity.Clear();

            using (var c = DbConnection.GetConnection())
            {
                c.Open();
                string sql = "SELECT name, price, stock FROM products WHERE name ILIKE @s";
                if (cbCategory.Text != "Все")
                    sql += " AND category_id=(SELECT id FROM sport_categories WHERE name=@c)";

                var cmd = new NpgsqlCommand(sql, c);
                cmd.Parameters.AddWithValue("@s", "%" + txtSearchProduct.Text + "%");
                if (cbCategory.Text != "Все")
                    cmd.Parameters.AddWithValue("@c", cbCategory.Text);

                var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    string name = r.GetString(0);
                    decimal price = r.GetDecimal(1);
                    int stock = r.GetInt32(2);

                    listProducts.Items.Add($"{name} - {price} ₽");
                    stockQuantity[name] = stock;
                }
                r.Close();
            }

            lblStock.Text = "На складе: ";
            nudQuantity.Value = 1;
        }

        private void ListProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listProducts.SelectedItem == null)
            {
                lblStock.Text = "На складе: ";
                nudQuantity.Maximum = 1;
                return;
            }

            string item = listProducts.SelectedItem.ToString().Split('-')[0].Trim();
            int stock = stockQuantity.ContainsKey(item) ? stockQuantity[item] : 0;
            lblStock.Text = "На складе: " + stock;
            nudQuantity.Maximum = stock > 0 ? stock : 1;
            nudQuantity.Value = 1;
        }

        // ---------- КОРЗИНА ----------
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            if (listProducts.SelectedItem == null) return;

            string itemName = listProducts.SelectedItem.ToString().Split('-')[0].Trim();
            decimal price = decimal.Parse(listProducts.SelectedItem.ToString().Split('-')[1].Replace("₽", "").Trim());
            int quantityToAdd = (int)nudQuantity.Value;

            if (!stockQuantity.ContainsKey(itemName)) return;

            if (quantityToAdd > stockQuantity[itemName])
            {
                MessageBox.Show("Нельзя добавить больше, чем на складе!");
                return;
            }

            string cartItem = $"{itemName} - {price} ₽";

            if (!cartQuantity.ContainsKey(cartItem))
                cartQuantity[cartItem] = 0;

            cartQuantity[cartItem] += quantityToAdd;
            listBoxCart.Items.Clear();
            foreach (var kv in cartQuantity)
            {
                listBoxCart.Items.Add($"{kv.Key} x{kv.Value}");
            }

            stockQuantity[itemName] -= quantityToAdd;
            totalSum += price * quantityToAdd;
            UpdateSum();
            ListProducts_SelectedIndexChanged(null, null); // обновить склад
        }

        private void BtnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (listBoxCart.SelectedItem == null) return;

            string cartText = listBoxCart.SelectedItem.ToString();
            string itemName = cartText.Split('-')[0].Trim();
            int quantity = int.Parse(cartText.Split('x')[1].Trim());

            decimal price = decimal.Parse(cartText.Split('-')[1].Split('₽')[0].Trim());

            // Возвращаем количество на склад
            if (stockQuantity.ContainsKey(itemName))
                stockQuantity[itemName] += quantity;

            // Удаляем из корзины
            string cartKey = $"{itemName} - {price} ₽";
            if (cartQuantity.ContainsKey(cartKey))
                cartQuantity.Remove(cartKey);

            listBoxCart.Items.Clear();
            foreach (var kv in cartQuantity)
            {
                listBoxCart.Items.Add($"{kv.Key} x{kv.Value}");
            }

            totalSum -= price * quantity;
            UpdateSum();
            ListProducts_SelectedIndexChanged(null, null);
        }

        private void UpdateSum()
        {
            decimal sum = totalSum;
            if (chkUseBonus.Checked)
            {
                sum -= clientBonus;
                if (sum < 0) sum = 0;
            }
            lblTotal.Text = "Сумма: " + sum + " ₽";
        }

        // ---------- КЛИЕНТ ----------
        private void BtnFindClient_Click(object sender, EventArgs e)
        {
            if (!txtPhone.MaskCompleted)
            {
                MessageBox.Show("Введите номер телефона клиента");
                return;
            }

            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand(
                    "SELECT id, full_name, email, phone, bonus_points FROM users WHERE phone = @p",
                    conn);
                cmd.Parameters.AddWithValue("@p", txtPhone.Text);

                var r = cmd.ExecuteReader();

                if (r.Read())
                {
                    clientId = r.GetInt32(0);
                    clientFio = r.GetString(1);
                    clientEmail = r.IsDBNull(2) ? "" : r.GetString(2);
                    clientPhone = r.GetString(3);
                    clientBonus = r.GetInt32(4);

                    lblBonus.Text = "Бонусы: " + clientBonus;
                    MessageBox.Show("Клиент найден:\n" + clientFio);
                }
                else
                {
                    r.Close();

                    var res = MessageBox.Show(
                        "Клиент не найден.\nЗарегистрировать нового клиента?",
                        "Клиент не найден",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        using (var regForm = new RegisterForm(txtPhone.Text))
                        {
                            if (regForm.ShowDialog() == DialogResult.OK || regForm.ClientId != -1)
                            {
                                clientId = regForm.ClientId;
                                clientBonus = 0;
                                lblBonus.Text = "Бонусы: " + clientBonus;
                                MessageBox.Show("Клиент зарегистрирован.\nТеперь можно оформить покупку.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Покупка будет оформлена без авторизации клиента");
                    }
                }
            }
        }

        // ---------- ОПЛАТА ----------
        private void BtnPay_Click(object sender, EventArgs e)
        {
            if (listBoxCart.Items.Count == 0)
            {
                MessageBox.Show("Добавьте товары!");
                return;
            }

            bool withoutClient = false;
            if (!txtPhone.MaskCompleted && clientId == -1)
            {
                var res = MessageBox.Show(
                    "Номер клиента не введён.\nПродолжить без авторизации?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo);

                if (res == DialogResult.No) return;
                withoutClient = true;
            }

            int usedBonus = chkUseBonus.Checked ? clientBonus : 0;
            decimal finalSum = totalSum - usedBonus;

            // --- Печать чека ---
            var printCheck = MessageBox.Show("Печать чека?", "Чек", MessageBoxButtons.YesNo);
            if (printCheck == DialogResult.Yes)
                CreateWordCheck(finalSum, usedBonus, withoutClient);

            // --- Обновление базы ---
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();

                // 1. Списание товаров со склада
                foreach (var kv in cartQuantity)
                {
                    string[] parts = kv.Key.Split('-');
                    string name = parts[0].Trim();
                    int quantity = kv.Value;

                    var cmdStock = new NpgsqlCommand(
                        "UPDATE products SET stock = stock - @qty WHERE name=@name", conn);
                    cmdStock.Parameters.AddWithValue("@qty", quantity);
                    cmdStock.Parameters.AddWithValue("@name", name);
                    cmdStock.ExecuteNonQuery();
                }

                if (!withoutClient && clientId != -1)
                {
                    // 2. Списание бонусов
                    if (chkUseBonus.Checked)
                    {
                        int remainingBonus = clientBonus - usedBonus;
                        if (remainingBonus < 0) remainingBonus = 0;

                        var cmdBonus = new NpgsqlCommand(
                            "UPDATE users SET bonus_points=@bp WHERE id=@id", conn);
                        cmdBonus.Parameters.AddWithValue("@bp", remainingBonus);
                        cmdBonus.Parameters.AddWithValue("@id", clientId);
                        cmdBonus.ExecuteNonQuery();
                        clientBonus = remainingBonus;
                    }

                    // 3. Начисление бонусов (например 5% от суммы покупки)
                    int addBonus = (int)(finalSum * 0.05m);
                    var cmdAddBonus = new NpgsqlCommand(
                        "UPDATE users SET bonus_points = bonus_points + @b WHERE id=@id", conn);
                    cmdAddBonus.Parameters.AddWithValue("@b", addBonus);
                    cmdAddBonus.Parameters.AddWithValue("@id", clientId);
                    cmdAddBonus.ExecuteNonQuery();

                    clientBonus += addBonus;
                }
            }

            MessageBox.Show($"Покупка оформлена!\nНачислено бонусов: {clientBonus}");
            ClearForm();
        }


        private void ClearForm()
        {
            listBoxCart.Items.Clear();
            cartQuantity.Clear();
            txtPhone.Clear();
            chkUseBonus.Checked = false;
            lblBonus.Text = "Бонусы: 0";
            totalSum = 0;
            clientId = -1;
            UpdateSum();
            LoadProducts();
        }

        // ---------- ЧЕК ----------
        private void CreateWordCheck(decimal sum, int bonus, bool withoutClient)
        {
            var app = new Word.Application();
            var doc = app.Documents.Add();

            doc.Content.Font.Name = "Times New Roman";
            doc.Content.Font.Size = 12;

            var para = doc.Paragraphs.Add();
            para.Range.Text = "ЧЕК ПРОДАЖИ";
            para.Range.Font.Bold = 1;
            para.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            para.Range.InsertParagraphAfter();

            para = doc.Paragraphs.Add();
            para.Range.Text = "Дата: " + DateTime.Now;
            para.Range.Font.Bold = 0;
            para.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            para.Range.InsertParagraphAfter();

            para = doc.Paragraphs.Add();
            para.Range.Text = "Кассир: " + cashierFio;
            para.Range.InsertParagraphAfter();

            if (withoutClient)
                para.Range.Text += "\nПокупка без авторизации клиента\n";
            else
            {
                para.Range.Text += "\nКлиент: " + clientFio;
                if (!string.IsNullOrEmpty(clientEmail))
                    para.Range.Text += "\nEmail: " + clientEmail;
                para.Range.Text += "\nТелефон: " + clientPhone + "\n";
            }

            Word.Table table = doc.Tables.Add(doc.Bookmarks.get_Item("\\endofdoc").Range,
                                              cartQuantity.Count + 1, 4);
            table.Borders.Enable = 1;
            table.Range.Font.Name = "Times New Roman";
            table.Range.Font.Size = 12;

            table.Cell(1, 1).Range.Text = "№";
            table.Cell(1, 2).Range.Text = "Товар";
            table.Cell(1, 3).Range.Text = "Цена";
            table.Cell(1, 4).Range.Text = "Кол-во";
            table.Rows[1].Range.Bold = 1;
            table.Rows[1].Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
            table.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            int i = 2;
            foreach (var kv in cartQuantity)
            {
                string[] parts = kv.Key.Split('-');
                string name = parts[0].Trim();
                string price = parts[1].Trim();
                table.Cell(i, 1).Range.Text = (i - 1).ToString();
                table.Cell(i, 2).Range.Text = name;
                table.Cell(i, 3).Range.Text = price;
                table.Cell(i, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                table.Cell(i, 4).Range.Text = kv.Value.ToString();
                table.Cell(i, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                i++;
            }

            para = doc.Paragraphs.Add();
            para.Range.Text = "\nБонусы списаны: " + bonus;
            para.Range.InsertParagraphAfter();
            para = doc.Paragraphs.Add();
            para.Range.Text = "ИТОГО: " + sum + " ₽";
            para.Range.Font.Bold = 1;

            app.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }
    }
}
