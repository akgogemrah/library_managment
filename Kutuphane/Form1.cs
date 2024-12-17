using System;
using System.Data.SQLite;
using System.Windows.Forms;


namespace Kutuphane
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=giris.db;Version=3;";
        public Form1()
        {
            InitializeComponent();
            VeritabaniKontrolEtVeOlustur();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void VeritabaniKontrolEtVeOlustur()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string createTableQuery = @"CREATE TABLE IF NOT EXISTS users (
                                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                username TEXT NOT NULL,
                                                password TEXT NOT NULL);";

                    using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }


                    string checkUserQuery = "SELECT COUNT(*) FROM users;";
                    using (SQLiteCommand command = new SQLiteCommand(checkUserQuery, connection))
                    {
                        int userCount = Convert.ToInt32(command.ExecuteScalar());
                        if (userCount == 0)
                        {
                            string insertUserQuery = "INSERT INTO users (username, password) VALUES ('admin', '1234');";
                            using (SQLiteCommand insertCommand = new SQLiteCommand(insertUserQuery, connection))
                            {
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }

        private bool KullaniciDogrula(string username, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int userCount = Convert.ToInt32(command.ExecuteScalar());
                        return userCount > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                    return false;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "Kullanıcı adı ve şifre boş olamaz!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            bool girisBasarili = KullaniciDogrula(username, password);

            if (girisBasarili)
            {
                lblMessage.Text = "Giriş başarılı! Hoş geldiniz.";
                lblMessage.ForeColor = System.Drawing.Color.Green;


                if (username == "admin" && password == "1234")
                {

                    Form2 form2 = new Form2(true);
                    form2.Show();
                }
                else
                {

                    Form2 form2 = new Form2(false);
                    form2.Show();
                }

                this.Hide();
            }
            else
            {
                lblMessage.Text = "Hatalı kullanıcı adı veya şifre!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
