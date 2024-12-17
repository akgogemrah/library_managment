namespace Kutuphane
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBookTitle = new TextBox();
            txtAuthor = new TextBox();
            txtYear = new TextBox();
            txtPage = new TextBox();
            btnAddBook = new Button();
            lblBookMessage = new Label();
            dataGridViewBooks = new DataGridView();
            btnDeleteBook = new Button();
            btnUpdateBook = new Button();
            KitapAta = new Button();
            buttonAdmin = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            SuspendLayout();
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(45, 34);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(165, 23);
            txtBookTitle.TabIndex = 0;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(45, 74);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(165, 23);
            txtAuthor.TabIndex = 1;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(45, 115);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(165, 23);
            txtYear.TabIndex = 2;
            // 
            // txtPage
            // 
            txtPage.Location = new Point(45, 156);
            txtPage.Name = "txtPage";
            txtPage.Size = new Size(165, 23);
            txtPage.TabIndex = 3;
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(81, 203);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(75, 23);
            btnAddBook.TabIndex = 4;
            btnAddBook.Text = "Kitap Ekle";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // lblBookMessage
            // 
            lblBookMessage.AutoSize = true;
            lblBookMessage.Location = new Point(193, 423);
            lblBookMessage.Name = "lblBookMessage";
            lblBookMessage.Size = new Size(38, 15);
            lblBookMessage.TabIndex = 5;
            lblBookMessage.Text = "label1";
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(250, -1);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.Size = new Size(538, 439);
            dataGridViewBooks.TabIndex = 6;
            dataGridViewBooks.CellClick += dataGridViewBooks_CellClick;
            dataGridViewBooks.CellContentClick += dataGridViewBooks_CellContentClick;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.Location = new Point(81, 232);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(75, 23);
            btnDeleteBook.TabIndex = 7;
            btnDeleteBook.Text = "Sil";
            btnDeleteBook.UseVisualStyleBackColor = true;
            btnDeleteBook.Click += btnDeleteBook_Click;
            // 
            // btnUpdateBook
            // 
            btnUpdateBook.Location = new Point(81, 261);
            btnUpdateBook.Name = "btnUpdateBook";
            btnUpdateBook.Size = new Size(75, 23);
            btnUpdateBook.TabIndex = 8;
            btnUpdateBook.Text = "Duzenle";
            btnUpdateBook.UseVisualStyleBackColor = true;
            btnUpdateBook.Click += btnUpdateBook_Click;
            // 
            // KitapAta
            // 
            KitapAta.Location = new Point(12, 345);
            KitapAta.Name = "KitapAta";
            KitapAta.Size = new Size(75, 23);
            KitapAta.TabIndex = 9;
            KitapAta.Text = "Odunc";
            KitapAta.UseVisualStyleBackColor = true;
            KitapAta.Click += KitapAta_Click;
            // 
            // buttonAdmin
            // 
            buttonAdmin.Location = new Point(12, 405);
            buttonAdmin.Name = "buttonAdmin";
            buttonAdmin.Size = new Size(75, 23);
            buttonAdmin.TabIndex = 10;
            buttonAdmin.Text = "Kullaniciekle";
            buttonAdmin.UseVisualStyleBackColor = true;
            buttonAdmin.Click += buttonAdmin_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonAdmin);
            Controls.Add(KitapAta);
            Controls.Add(btnUpdateBook);
            Controls.Add(btnDeleteBook);
            Controls.Add(dataGridViewBooks);
            Controls.Add(lblBookMessage);
            Controls.Add(btnAddBook);
            Controls.Add(txtPage);
            Controls.Add(txtYear);
            Controls.Add(txtAuthor);
            Controls.Add(txtBookTitle);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBookTitle;
        private TextBox txtAuthor;
        private TextBox txtYear;
        private TextBox txtPage;
        private Button btnAddBook;
        private Label lblBookMessage;
        private DataGridView dataGridViewBooks;
        private Button btnDeleteBook;
        private Button btnUpdateBook;
        private Button KitapAta;
        private Button buttonAdmin;
    }
}