namespace PTPMUD_Project
{
    partial class Home
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btnViewBill = new Guna.UI2.WinForms.Guna2Button();
            dtpkToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dtpkFromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dtgvBill = new Guna.UI2.WinForms.Guna2DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvBill).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnViewBill);
            panel1.Controls.Add(dtpkToDate);
            panel1.Controls.Add(dtpkFromDate);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(752, 94);
            panel1.TabIndex = 2;
            // 
            // btnViewBill
            // 
            btnViewBill.BorderRadius = 10;
            btnViewBill.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            btnViewBill.CustomizableEdges = customizableEdges1;
            btnViewBill.DisabledState.BorderColor = Color.DarkGray;
            btnViewBill.DisabledState.CustomBorderColor = Color.DarkGray;
            btnViewBill.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnViewBill.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnViewBill.FillColor = Color.FromArgb(0, 127, 255);
            btnViewBill.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnViewBill.ForeColor = Color.White;
            btnViewBill.Location = new Point(275, 16);
            btnViewBill.Margin = new Padding(3, 2, 3, 2);
            btnViewBill.Name = "btnViewBill";
            btnViewBill.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnViewBill.Size = new Size(197, 42);
            btnViewBill.TabIndex = 3;
            btnViewBill.Text = "Thống Kê";
            btnViewBill.Click += btnViewBill_Click;
            // 
            // dtpkToDate
            // 
            dtpkToDate.Checked = true;
            dtpkToDate.CustomizableEdges = customizableEdges3;
            dtpkToDate.FillColor = Color.FromArgb(255, 255, 128);
            dtpkToDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtpkToDate.Format = DateTimePickerFormat.Long;
            dtpkToDate.Location = new Point(521, 24);
            dtpkToDate.Margin = new Padding(3, 2, 3, 2);
            dtpkToDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpkToDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpkToDate.Name = "dtpkToDate";
            dtpkToDate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            dtpkToDate.Size = new Size(219, 34);
            dtpkToDate.TabIndex = 2;
            dtpkToDate.Value = new DateTime(2024, 2, 18, 17, 0, 5, 788);
            // 
            // dtpkFromDate
            // 
            dtpkFromDate.Checked = true;
            dtpkFromDate.CustomizableEdges = customizableEdges5;
            dtpkFromDate.FillColor = Color.FromArgb(255, 255, 128);
            dtpkFromDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtpkFromDate.Format = DateTimePickerFormat.Long;
            dtpkFromDate.Location = new Point(12, 24);
            dtpkFromDate.Margin = new Padding(3, 2, 3, 2);
            dtpkFromDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpkFromDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpkFromDate.Name = "dtpkFromDate";
            dtpkFromDate.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dtpkFromDate.Size = new Size(219, 34);
            dtpkFromDate.TabIndex = 1;
            dtpkFromDate.Value = new DateTime(2024, 2, 18, 16, 59, 58, 756);
            // 
            // dtgvBill
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dtgvBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtgvBill.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgvBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgvBill.ColumnHeadersHeight = 30;
            dtgvBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgvBill.DefaultCellStyle = dataGridViewCellStyle3;
            dtgvBill.Dock = DockStyle.Fill;
            dtgvBill.GridColor = Color.FromArgb(231, 229, 255);
            dtgvBill.Location = new Point(0, 94);
            dtgvBill.Margin = new Padding(3, 2, 3, 2);
            dtgvBill.Name = "dtgvBill";
            dtgvBill.RowHeadersVisible = false;
            dtgvBill.RowHeadersWidth = 51;
            dtgvBill.RowTemplate.Height = 29;
            dtgvBill.Size = new Size(752, 462);
            dtgvBill.TabIndex = 3;
            dtgvBill.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dtgvBill.ThemeStyle.AlternatingRowsStyle.Font = null;
            dtgvBill.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dtgvBill.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dtgvBill.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dtgvBill.ThemeStyle.BackColor = Color.White;
            dtgvBill.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dtgvBill.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dtgvBill.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgvBill.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtgvBill.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dtgvBill.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgvBill.ThemeStyle.HeaderStyle.Height = 30;
            dtgvBill.ThemeStyle.ReadOnly = false;
            dtgvBill.ThemeStyle.RowsStyle.BackColor = Color.White;
            dtgvBill.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgvBill.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtgvBill.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dtgvBill.ThemeStyle.RowsStyle.Height = 29;
            dtgvBill.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dtgvBill.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(752, 556);
            Controls.Add(dtgvBill);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Home";
            Text = "Home";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvBill).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpkToDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpkFromDate;
        private Guna.UI2.WinForms.Guna2DataGridView dtgvBill;
        private Guna.UI2.WinForms.Guna2Button btnViewBill;
    }
}