using PTPMUD_Project.BUS;
using PTPMUD_Project.DAO;
using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTPMUD_Project
{
    public partial class Table : Form
    {
        public Table()
        {
            InitializeComponent();
            tableFoodBus = new TableFoodBUS();
            billBus = new BillBUS();
            load();
        }
        TableFoodBUS tableFoodBus;
        BillBUS billBus;
        #region Methods
        void load()
        {
            loadListTable();
            AddFoodBiding();
        }
        void loadListTable()
        {
            dtgvTable.DataSource = tableFoodBus.getALLTable();
        }
        void AddFoodBiding()
        {
            txtTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "tableName", true, DataSourceUpdateMode.Never));
            txtTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "idTable", true, DataSourceUpdateMode.Never));
            cboStatus.DataBindings.Add(new Binding("SelectedItem", dtgvTable.DataSource, "status", true, DataSourceUpdateMode.Never));
            txtNote.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "note", true, DataSourceUpdateMode.Never));
        }
        #endregion

        #region Events


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtTableID_TextChanged(object sender, EventArgs e)
        {
            if (dtgvTable.SelectedCells.Count > 0)
            {
                int id = Convert.ToInt32(txtTableID.Text);
                string status = (dtgvTable.SelectedCells[0].OwningRow.Cells["Status"].Value).ToString();

                string tableStatus = tableFoodBus.GetStatusByID(id);
                if (status == tableStatus)
                {
                    cboStatus.SelectedItem = tableStatus;
                }


            }
        }
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string tableName = txtTableName.Text;
            string status = cboStatus.SelectedItem as string;
            string note = txtNote.Text;

            if (tableFoodBus.InserTable(tableName, status, note))
            {
                MessageBox.Show("Thêm món thành công");
                loadListTable();
                //if (insertFood != null)
                //    insertFood(this, new EventArgs());

            }
            else
            {
                MessageBox.Show("Có lối khi thêm thức ăn");
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            string tableName = txtTableName.Text;
            string status = cboStatus.SelectedItem as string;
            string note = txtNote.Text;
            int id = Convert.ToInt32(txtTableID.Text);

            if (tableFoodBus.UpdateTable(id, tableName, status, note))
            {
                MessageBox.Show("Sửa món thành công");
                loadListTable();
                //if (updateFood != null)
                //    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lối khi sửa món ăn");
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            string id = txtTableID.Text;
            if (tableFoodBus.DeleteTable(id))
            {
                MessageBox.Show("Xóa món thành công");
                loadListTable();
                //if (deleteFood != null)
                //    deleteFood(this, new EventArgs());

            }
            else
            {
                MessageBox.Show("Có lỗii khi Xóa món ăn");
            }
        }

        #endregion

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }


    }
}
