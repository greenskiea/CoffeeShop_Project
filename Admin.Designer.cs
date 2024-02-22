namespace PTPMUD_Project
{
    partial class Admin
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            btnAdd = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            EmployeeDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            btnUpdate = new Guna.UI2.WinForms.Guna2PictureBox();
            btnDelete = new Guna.UI2.WinForms.Guna2PictureBox();
            txtSearchName = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)btnAdd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmployeeDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnUpdate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnDelete).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(47, 18);
            label1.Name = "label1";
            label1.Size = new Size(181, 57);
            label1.TabIndex = 0;
            label1.Text = "Staff List";
            // 
            // btnAdd
            // 
            btnAdd.CustomizableEdges = customizableEdges1;
            btnAdd.Image = Properties.Resources.Plus_icon;
            btnAdd.ImageRotate = 0F;
            btnAdd.Location = new Point(47, 88);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAdd.Size = new Size(64, 64);
            btnAdd.SizeMode = PictureBoxSizeMode.Zoom;
            btnAdd.TabIndex = 1;
            btnAdd.TabStop = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // guna2Separator1
            // 
            guna2Separator1.Location = new Point(47, 178);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(1223, 12);
            guna2Separator1.TabIndex = 2;
            // 
            // EmployeeDataGridView
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            EmployeeDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            EmployeeDataGridView.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 48, 96);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            EmployeeDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            EmployeeDataGridView.ColumnHeadersHeight = 50;
            EmployeeDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            EmployeeDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            EmployeeDataGridView.GridColor = Color.FromArgb(231, 229, 255);
            EmployeeDataGridView.Location = new Point(47, 196);
            EmployeeDataGridView.Name = "EmployeeDataGridView";
            EmployeeDataGridView.ReadOnly = true;
            EmployeeDataGridView.RowHeadersVisible = false;
            EmployeeDataGridView.RowHeadersWidth = 51;
            EmployeeDataGridView.RowTemplate.Height = 29;
            EmployeeDataGridView.Size = new Size(1223, 453);
            EmployeeDataGridView.TabIndex = 3;
            EmployeeDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            EmployeeDataGridView.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EmployeeDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            EmployeeDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            EmployeeDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            EmployeeDataGridView.ThemeStyle.BackColor = Color.White;
            EmployeeDataGridView.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            EmployeeDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(0, 48, 96);
            EmployeeDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            EmployeeDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EmployeeDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            EmployeeDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            EmployeeDataGridView.ThemeStyle.HeaderStyle.Height = 50;
            EmployeeDataGridView.ThemeStyle.ReadOnly = true;
            EmployeeDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            EmployeeDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            EmployeeDataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            EmployeeDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            EmployeeDataGridView.ThemeStyle.RowsStyle.Height = 29;
            EmployeeDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            EmployeeDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            EmployeeDataGridView.CellFormatting += EmployeeDataGridView_CellFormatting;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.CustomizableEdges = customizableEdges3;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(141, 88);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2PictureBox1.Size = new Size(75, 75);
            guna2PictureBox1.TabIndex = 4;
            guna2PictureBox1.TabStop = false;
            // 
            // btnUpdate
            // 
            btnUpdate.CustomizableEdges = customizableEdges5;
            btnUpdate.Image = Properties.Resources.Update_icon;
            btnUpdate.ImageRotate = 0F;
            btnUpdate.Location = new Point(141, 88);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnUpdate.Size = new Size(75, 75);
            btnUpdate.SizeMode = PictureBoxSizeMode.Zoom;
            btnUpdate.TabIndex = 4;
            btnUpdate.TabStop = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.CustomizableEdges = customizableEdges7;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageRotate = 0F;
            btnDelete.Location = new Point(238, 88);
            btnDelete.Name = "btnDelete";
            btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnDelete.Size = new Size(75, 75);
            btnDelete.SizeMode = PictureBoxSizeMode.Zoom;
            btnDelete.TabIndex = 4;
            btnDelete.TabStop = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtSearchName
            // 
            txtSearchName.CustomizableEdges = customizableEdges9;
            txtSearchName.DefaultText = "";
            txtSearchName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearchName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearchName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearchName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearchName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearchName.ForeColor = Color.Black;
            txtSearchName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchName.Location = new Point(974, 106);
            txtSearchName.Margin = new Padding(3, 4, 3, 4);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.PasswordChar = '\0';
            txtSearchName.PlaceholderText = "Search .....";
            txtSearchName.SelectedText = "";
            txtSearchName.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtSearchName.Size = new Size(296, 46);
            txtSearchName.TabIndex = 13;
            txtSearchName.TextChanged += txtSearchName_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(974, 62);
            label2.Name = "label2";
            label2.Size = new Size(123, 28);
            label2.TabIndex = 14;
            label2.Text = "Filter Name";
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1346, 781);
            Controls.Add(label2);
            Controls.Add(txtSearchName);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(guna2PictureBox1);
            Controls.Add(EmployeeDataGridView);
            Controls.Add(guna2Separator1);
            Controls.Add(btnAdd);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Admin";
            Text = "Admin";
            Load += Admin_Load;
            ((System.ComponentModel.ISupportInitialize)btnAdd).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmployeeDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnUpdate).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnDelete).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2DataGridView EmployeeDataGridView;
        public Guna.UI2.WinForms.Guna2PictureBox btnAdd;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox btnUpdate;
        private Guna.UI2.WinForms.Guna2PictureBox btnDelete;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchName;
        private Label label2;
    }
}