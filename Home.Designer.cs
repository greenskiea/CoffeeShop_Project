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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btnViewBill = new Guna.UI2.WinForms.Guna2Button();
            dtpkToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dtpkFromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnViewBill);
            panel1.Controls.Add(dtpkToDate);
            panel1.Controls.Add(dtpkFromDate);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1346, 114);
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
            btnViewBill.Location = new Point(530, 29);
            btnViewBill.Name = "btnViewBill";
            btnViewBill.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnViewBill.Size = new Size(225, 56);
            btnViewBill.TabIndex = 3;
            btnViewBill.Text = "Thống Kê";
            btnViewBill.Click += btnViewBill_Click;
            // 
            // dtpkToDate
            // 
            dtpkToDate.Checked = true;
            dtpkToDate.CustomFormat = "dd-MM-yyyy";
            dtpkToDate.CustomizableEdges = customizableEdges3;
            dtpkToDate.FillColor = Color.FromArgb(255, 255, 128);
            dtpkToDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtpkToDate.Format = DateTimePickerFormat.Custom;
            dtpkToDate.Location = new Point(811, 40);
            dtpkToDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpkToDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpkToDate.Name = "dtpkToDate";
            dtpkToDate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            dtpkToDate.Size = new Size(250, 45);
            dtpkToDate.TabIndex = 2;
            dtpkToDate.Value = new DateTime(2024, 2, 18, 17, 0, 5, 788);
            // 
            // dtpkFromDate
            // 
            dtpkFromDate.Checked = true;
            dtpkFromDate.CustomFormat = "dd-MM-yyyy";
            dtpkFromDate.CustomizableEdges = customizableEdges5;
            dtpkFromDate.FillColor = Color.FromArgb(255, 255, 128);
            dtpkFromDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtpkFromDate.Format = DateTimePickerFormat.Custom;
            dtpkFromDate.Location = new Point(230, 40);
            dtpkFromDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpkFromDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpkFromDate.Name = "dtpkFromDate";
            dtpkFromDate.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dtpkFromDate.Size = new Size(250, 45);
            dtpkFromDate.TabIndex = 1;
            dtpkFromDate.Value = new DateTime(2024, 2, 18, 16, 59, 58, 756);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(14, 132);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(679, 530);
            chart1.TabIndex = 3;
            chart1.Text = "chart1";
            // 
            // DataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DataGridView1.ColumnHeadersHeight = 100;
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            DataGridView1.Location = new Point(715, 132);
            DataGridView1.Name = "DataGridView1";
            DataGridView1.ReadOnly = true;
            DataGridView1.RowHeadersVisible = false;
            DataGridView1.RowHeadersWidth = 51;
            DataGridView1.RowTemplate.Height = 29;
            DataGridView1.Size = new Size(577, 509);
            DataGridView1.TabIndex = 4;
            DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            DataGridView1.ThemeStyle.BackColor = Color.White;
            DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DataGridView1.ThemeStyle.HeaderStyle.Height = 100;
            DataGridView1.ThemeStyle.ReadOnly = true;
            DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            DataGridView1.ThemeStyle.RowsStyle.Height = 29;
            DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1346, 781);
            Controls.Add(DataGridView1);
            Controls.Add(chart1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Home";
            Text = "Home";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpkToDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpkFromDate;
        private Guna.UI2.WinForms.Guna2Button btnViewBill;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridView1;
    }
}