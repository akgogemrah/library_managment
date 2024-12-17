namespace Kutuphane
{
    partial class Form3
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
            cmbBooks = new ComboBox();
            cmbStatus = new ComboBox();
            txtName = new TextBox();
            txtPhone = new TextBox();
            btnAssignBook = new Button();
            dataGridViewAssignedBooks = new DataGridView();
            btnUpdateBook = new Button();
            btnDeleteBook = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssignedBooks).BeginInit();
            SuspendLayout();
            // 
            // cmbBooks
            // 
            cmbBooks.FormattingEnabled = true;
            cmbBooks.Location = new Point(24, 33);
            cmbBooks.Name = "cmbBooks";
            cmbBooks.Size = new Size(121, 23);
            cmbBooks.TabIndex = 0;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(24, 155);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(121, 23);
            cmbStatus.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(24, 72);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 2;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(24, 114);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(100, 23);
            txtPhone.TabIndex = 3;
            // 
            // btnAssignBook
            // 
            btnAssignBook.Location = new Point(55, 200);
            btnAssignBook.Name = "btnAssignBook";
            btnAssignBook.Size = new Size(75, 23);
            btnAssignBook.TabIndex = 4;
            btnAssignBook.Text = "odunc ver";
            btnAssignBook.UseVisualStyleBackColor = true;
            btnAssignBook.Click += btnAssignBook_Click;
            // 
            // dataGridViewAssignedBooks
            // 
            dataGridViewAssignedBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAssignedBooks.Location = new Point(195, 3);
            dataGridViewAssignedBooks.Name = "dataGridViewAssignedBooks";
            dataGridViewAssignedBooks.Size = new Size(599, 447);
            dataGridViewAssignedBooks.TabIndex = 5;
            dataGridViewAssignedBooks.CellClick += dataGridViewAssignedBooks_CellClick;
            dataGridViewAssignedBooks.CellContentClick += dataGridViewAssignedBooks_CellContentClick;
            // 
            // btnUpdateBook
            // 
            btnUpdateBook.Location = new Point(55, 229);
            btnUpdateBook.Name = "btnUpdateBook";
            btnUpdateBook.Size = new Size(75, 23);
            btnUpdateBook.TabIndex = 6;
            btnUpdateBook.Text = "duzenle";
            btnUpdateBook.UseVisualStyleBackColor = true;
            btnUpdateBook.Click += btnUpdateBook_Click;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.Location = new Point(55, 254);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(75, 23);
            btnDeleteBook.TabIndex = 7;
            btnDeleteBook.Text = "sil";
            btnDeleteBook.UseVisualStyleBackColor = true;
            btnDeleteBook.Click += btnDeleteBook_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteBook);
            Controls.Add(btnUpdateBook);
            Controls.Add(dataGridViewAssignedBooks);
            Controls.Add(btnAssignBook);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(cmbStatus);
            Controls.Add(cmbBooks);
            Name = "Form3";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssignedBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBooks;
        private ComboBox cmbStatus;
        private TextBox txtName;
        private TextBox txtPhone;
        private Button btnAssignBook;
        private DataGridView dataGridViewAssignedBooks;
        private Button btnUpdateBook;
        private Button btnDeleteBook;
    }
}