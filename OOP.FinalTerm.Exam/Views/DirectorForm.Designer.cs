namespace OOP.FinalTerm.Exam.Views
{
    partial class DirectorForm
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
            panel1 = new Panel();
            lblTitle = new Label();
            panel2 = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panel3 = new Panel();
            numTotalMovies = new NumericUpDown();
            txtGenres = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTotalMovies).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 20, 20);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 50);
            panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(127, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add Director";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(20, 20, 20);
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnSave);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 410);
            panel2.Name = "panel2";
            panel2.Size = new Size(500, 60);
            panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(60, 60, 60);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(270, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(221, 0, 0);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(130, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(30, 30, 30);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(numTotalMovies);
            panel3.Controls.Add(txtGenres);
            panel3.Controls.Add(txtLastName);
            panel3.Controls.Add(txtFirstName);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 50);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(15);
            panel3.Size = new Size(500, 360);
            panel3.TabIndex = 2;
            // 
            // numTotalMovies
            // 
            numTotalMovies.Font = new Font("Segoe UI", 18F);
            numTotalMovies.Location = new Point(130, 285);
            numTotalMovies.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numTotalMovies.Name = "numTotalMovies";
            numTotalMovies.Size = new Size(242, 39);
            numTotalMovies.TabIndex = 5;
            // 
            // txtGenres
            // 
            txtGenres.Font = new Font("Segoe UI", 18F);
            txtGenres.Location = new Point(181, 154);
            txtGenres.Name = "txtGenres";
            txtGenres.Size = new Size(242, 39);
            txtGenres.TabIndex = 4;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 18F);
            txtLastName.Location = new Point(181, 85);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(242, 39);
            txtLastName.TabIndex = 3;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 18F);
            txtFirstName.Location = new Point(181, 22);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(242, 39);
            txtFirstName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.Font = new Font("Segoe UI", 18F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(18, 25);
            label1.Name = "label1";
            label1.Size = new Size(129, 32);
            label1.TabIndex = 6;
            label1.Text = "First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.Font = new Font("Segoe UI", 18F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(18, 88);
            label2.Name = "label2";
            label2.Size = new Size(126, 32);
            label2.TabIndex = 7;
            label2.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.Font = new Font("Segoe UI", 18F);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(18, 157);
            label3.Name = "label3";
            label3.Size = new Size(152, 32);
            label3.TabIndex = 8;
            label3.Text = "Movie Genre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(64, 64, 64);
            label4.Font = new Font("Segoe UI", 18F);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(116, 236);
            label4.Name = "label4";
            label4.Size = new Size(273, 32);
            label4.TabIndex = 9;
            label4.Text = "Total Number of Movies";
            // 
            // DirectorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            CancelButton = btnCancel;
            ClientSize = new Size(500, 470);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DirectorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Director";
            Load += DirectorForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTotalMovies).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTitle;
        private Panel panel2;
        private Button btnCancel;
        private Button btnSave;
        private Panel panel3;
        private NumericUpDown numTotalMovies;
        private TextBox txtGenres;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}