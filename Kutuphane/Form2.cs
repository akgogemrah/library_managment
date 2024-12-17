using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class Form2 : Form
    {
        private string connectionString = "Data Source=giris.db;Version=3;";
        private int selectedBookId = -1;
        private bool isAdmin;
        public Form2(bool adminStatus)
        {
            InitializeComponent();
            this.isAdmin = adminStatus;
            KitapTablosuKontrolEtVeOlustur();
            KitaplariYukle(); 
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string title = txtBookTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string year = txtYear.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(year))
            {
                MessageBox.Show("Tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO books (title, author, year) VALUES (@title, @author, @year);";

                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@author", author);
                    command.Parameters.AddWithValue("@year", year);

                    command.ExecuteNonQuery();
                }
            }

            KitaplariYukle();
            Temizle();
        }
        private void KitapTablosuKontrolEtVeOlustur()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string createTableQuery = @"CREATE TABLE IF NOT EXISTS books (
                                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                title TEXT NOT NULL,
                                                author TEXT NOT NULL,
                                                year TEXT NOT NULL);";

                    using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }
        private void KitapEkle(string title, string author, string year)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO books (title, author, year) VALUES (@title, @author, @year);";

                    using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@author", author);
                        command.Parameters.AddWithValue("@year", year);

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            lblBookMessage.Text = "Kitap başarıyla eklendi!";
                            lblBookMessage.ForeColor = System.Drawing.Color.Green;

                            KitaplariYukle(); 
                        }
                        else
                        {
                            lblBookMessage.Text = "Kitap eklenemedi!";
                            lblBookMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void KitaplariYukle()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM books";

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectQuery, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewBooks.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void dataGridViewBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewBooks.Rows[e.RowIndex];

                selectedBookId = Convert.ToInt32(row.Cells["id"].Value);
                txtBookTitle.Text = row.Cells["title"].Value.ToString();
                txtAuthor.Text = row.Cells["author"].Value.ToString();
                txtYear.Text = row.Cells["year"].Value.ToString();
            }
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            if (selectedBookId == -1)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz kitabı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE books SET title = @title, author = @author, year = @year WHERE id = @id;";

                using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@title", txtBookTitle.Text.Trim());
                    command.Parameters.AddWithValue("@author", txtAuthor.Text.Trim());
                    command.Parameters.AddWithValue("@year", txtYear.Text.Trim());
                    command.Parameters.AddWithValue("@id", selectedBookId);

                    command.ExecuteNonQuery();
                }
            }

            KitaplariYukle();
            Temizle();
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (selectedBookId == -1)
            {
                MessageBox.Show("Lütfen silmek istediğiniz kitabı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM books WHERE id = @id;";

                using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", selectedBookId);
                    command.ExecuteNonQuery();
                }
            }

            KitaplariYukle();
            Temizle();
        }
        private void Temizle()
        {
            txtBookTitle.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
            selectedBookId = -1;
        }

        private void KitapAta_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            Form3.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                buttonAdmin.Visible = true;
            }
            else
            {
                buttonAdmin.Visible = false;
            }
        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4();
            Form4.Show();
        }

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
