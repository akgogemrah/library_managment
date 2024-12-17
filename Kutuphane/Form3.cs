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
    public partial class Form3 : Form
    {
        private string connectionString = "Data Source=giris.db;Version=3;";
        public Form3()
        {
            InitializeComponent();
            VeritabaniTablolariniOlustur();
            KitaplariComboboxaYukle();
            AtananKitaplariGoster();
            cmbStatus.Items.Add("Dolu");
            cmbStatus.Items.Add("Boş");
            cmbStatus.SelectedIndex = 0; 
        }
        private void VeritabaniTablolariniOlustur()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createBooksTable = @"CREATE TABLE IF NOT EXISTS books (
                                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                title TEXT NOT NULL
                                            );";

                string createAssignedBooksTable = @"CREATE TABLE IF NOT EXISTS assigned_books (
                                                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                        book_title TEXT NOT NULL,
                                                        person_name TEXT NOT NULL,
                                                        phone_number TEXT NOT NULL
                                                    );";

                using (SQLiteCommand command = new SQLiteCommand(createBooksTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (SQLiteCommand command = new SQLiteCommand(createAssignedBooksTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        private void btnAssignBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbBooks.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string status = cmbStatus.SelectedItem.ToString();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                if (status == "Dolu")
                {
                    // Kitabı kullanıcıya ata
                    string insertQuery = @"INSERT INTO assigned_books (book_title, person_name, phone_number) 
                                           VALUES (@bookTitle, @personName, @phoneNumber);";
                    using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@bookTitle", cmbBooks.Text);
                        command.Parameters.AddWithValue("@personName", txtName.Text);
                        command.Parameters.AddWithValue("@phoneNumber", txtPhone.Text);
                        command.ExecuteNonQuery();
                    }


                }
                else
                {
                    // "Boş" seçilirse sadece kitabı listeden kaldır
                    string deleteQuery = "DELETE FROM assigned_books WHERE book_title = @bookTitle;";
                    using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@bookTitle", cmbBooks.Text);
                        command.ExecuteNonQuery();
                    }
                }
            }

            KitaplariComboboxaYukle();
            AtananKitaplariGoster();
            Temizle();
        }
        private void KitaplariComboboxaYukle()
        {
            cmbBooks.Items.Clear();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT title FROM books";

                using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbBooks.Items.Add(reader["title"].ToString());
                    }
                }
            }
        }


        private void AtananKitaplariGoster()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM assigned_books";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectQuery, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewAssignedBooks.DataSource = dt;
                }
            }
        }


        private void Temizle()
        {
            txtName.Clear();
            txtPhone.Clear();
            cmbBooks.SelectedIndex = -1;
            cmbStatus.SelectedIndex = 0;
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbBooks.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string updateQuery = @"UPDATE assigned_books SET 
                                        person_name = @personName, 
                                        phone_number = @phoneNumber 
                                        WHERE book_title = @bookTitle;";

                using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@bookTitle", cmbBooks.Text);
                    command.Parameters.AddWithValue("@personName", txtName.Text);
                    command.Parameters.AddWithValue("@phoneNumber", txtPhone.Text);
                    command.ExecuteNonQuery();
                }
            }

            AtananKitaplariGoster();
            Temizle();
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbBooks.Text))
            {
                MessageBox.Show("Lütfen silinecek kitabı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = @"DELETE FROM assigned_books WHERE book_title = @bookTitle;";

                using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@bookTitle", cmbBooks.Text);
                    command.ExecuteNonQuery();
                }
            }

            AtananKitaplariGoster();
            Temizle();
        }

        private void dataGridViewAssignedBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;

            if (selectedRowIndex >= 0)
            {
                // Seçili satırdaki kitap bilgilerini al
                string bookTitle = dataGridViewAssignedBooks.Rows[selectedRowIndex].Cells["book_title"].Value.ToString();
                string personName = dataGridViewAssignedBooks.Rows[selectedRowIndex].Cells["person_name"].Value.ToString();
                string phoneNumber = dataGridViewAssignedBooks.Rows[selectedRowIndex].Cells["phone_number"].Value.ToString();

                // TextBox ve ComboBox'a yansıt
                cmbBooks.Text = bookTitle;
                txtName.Text = personName;
                txtPhone.Text = phoneNumber;
            }
        }

        private void dataGridViewAssignedBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

