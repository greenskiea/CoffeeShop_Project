namespace PTPMUD_Project
{
    partial class Product
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Product));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            label1 = new Label();
            treeView1 = new TreeView();
            panel1 = new Panel();
            panel2 = new Panel();
            listView1 = new ListView();
            colFood_ID = new ColumnHeader();
            colFood_Name = new ColumnHeader();
            colPrice = new ColumnHeader();
            colCategory_ID = new ColumnHeader();
            colQuantity = new ColumnHeader();
            colType = new ColumnHeader();
            colPromotion = new ColumnHeader();
            pictureBox1 = new PictureBox();
            btnAddFood = new Guna.UI2.WinForms.Guna2ImageButton();
            btnDeleteFood = new Guna.UI2.WinForms.Guna2ImageButton();
            btnEditFood = new Guna.UI2.WinForms.Guna2ImageButton();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(guna2Button1);
            guna2Panel1.Controls.Add(btnEditFood);
            guna2Panel1.Controls.Add(btnDeleteFood);
            guna2Panel1.Controls.Add(btnAddFood);
            guna2Panel1.Controls.Add(pictureBox1);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.CustomizableEdges = customizableEdges6;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.FillColor = Color.FromArgb(50, 55, 89);
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges7;
            guna2Panel1.Size = new Size(1183, 159);
            guna2Panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(92, 27);
            label1.Name = "label1";
            label1.Size = new Size(96, 32);
            label1.TabIndex = 1;
            label1.Text = "Product";
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(250, 593);
            treeView1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(treeView1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 159);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 593);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(listView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(250, 159);
            panel2.Name = "panel2";
            panel2.Size = new Size(933, 593);
            panel2.TabIndex = 3;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { colFood_ID, colFood_Name, colPrice, colCategory_ID, colQuantity, colType, colPromotion });
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(933, 593);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // colFood_ID
            // 
            colFood_ID.Text = "ID";
            // 
            // colFood_Name
            // 
            colFood_Name.Text = "Name";
            // 
            // colPrice
            // 
            colPrice.Text = "Price";
            // 
            // colCategory_ID
            // 
            colCategory_ID.Text = "Category";
            // 
            // colQuantity
            // 
            colQuantity.Text = "Quantity";
            // 
            // colType
            // 
            colType.Text = "Type";
            // 
            // colPromotion
            // 
            colPromotion.Text = "Promotion";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 65);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btnAddFood
            // 
            btnAddFood.CheckedState.ImageSize = new Size(64, 64);
            btnAddFood.HoverState.ImageSize = new Size(64, 64);
            btnAddFood.Image = (Image)resources.GetObject("btnAddFood.Image");
            btnAddFood.ImageOffset = new Point(0, 0);
            btnAddFood.ImageRotate = 0F;
            btnAddFood.Location = new Point(325, 63);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.PressedState.ImageSize = new Size(64, 64);
            btnAddFood.ShadowDecoration.CustomizableEdges = customizableEdges5;
            btnAddFood.Size = new Size(80, 68);
            btnAddFood.TabIndex = 3;
            // 
            // btnDeleteFood
            // 
            btnDeleteFood.CheckedState.ImageSize = new Size(64, 64);
            btnDeleteFood.HoverState.ImageSize = new Size(64, 64);
            btnDeleteFood.Image = (Image)resources.GetObject("btnDeleteFood.Image");
            btnDeleteFood.ImageOffset = new Point(0, 0);
            btnDeleteFood.ImageRotate = 0F;
            btnDeleteFood.Location = new Point(510, 63);
            btnDeleteFood.Name = "btnDeleteFood";
            btnDeleteFood.PressedState.ImageSize = new Size(64, 64);
            btnDeleteFood.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnDeleteFood.Size = new Size(80, 68);
            btnDeleteFood.TabIndex = 4;
            // 
            // btnEditFood
            // 
            btnEditFood.CheckedState.ImageSize = new Size(64, 64);
            btnEditFood.HoverState.ImageSize = new Size(64, 64);
            btnEditFood.Image = (Image)resources.GetObject("btnEditFood.Image");
            btnEditFood.ImageOffset = new Point(0, 0);
            btnEditFood.ImageRotate = 0F;
            btnEditFood.Location = new Point(678, 63);
            btnEditFood.Name = "btnEditFood";
            btnEditFood.PressedState.ImageSize = new Size(64, 64);
            btnEditFood.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnEditFood.Size = new Size(80, 68);
            btnEditFood.TabIndex = 5;
            // 
            // guna2Button1
            // 
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(34, 83);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(166, 56);
            guna2Button1.TabIndex = 6;
            guna2Button1.Text = "guna2Button1";
            // 
            // Product
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1183, 752);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(guna2Panel1);
            ForeColor = Color.FromArgb(64, 64, 64);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Product";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product";
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label label1;
        private TreeView treeView1;
        private Panel panel1;
        private Panel panel2;
        private ListView listView1;
        private ColumnHeader colFood_ID;
        private ColumnHeader colFood_Name;
        private ColumnHeader colPrice;
        private ColumnHeader colCategory_ID;
        private ColumnHeader colQuantity;
        private ColumnHeader colType;
        private ColumnHeader colPromotion;
        private Guna.UI2.WinForms.Guna2ImageButton btnEditFood;
        private Guna.UI2.WinForms.Guna2ImageButton btnDeleteFood;
        private Guna.UI2.WinForms.Guna2ImageButton btnAddFood;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}