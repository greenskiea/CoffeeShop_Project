using Guna.UI2.WinForms;
using PTPMUD_Project.BUS;
using PTPMUD_Project.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PTPMUD_Project
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            billBus = new BillBUS();
            load();
        }
        BillBUS billBus;
        #region Methods
        void load()
        {
            loadDateTimePickerBill();
            loadListBillbyDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        void loadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }

        void loadListBillbyDate(DateTime checkedFrom, DateTime checkedTo)
        {
            //dtgvBill.DataSource = billBus.GetListBillByDate(checkedFrom, checkedTo);
        }
        #endregion

        private void UpdateChart()
        {
            // Lấy ngày bắt đầu và ngày kết thúc từ DateTimePicker
            DateTime startDate = dtpkFromDate.Value;
            DateTime endDate = dtpkToDate.Value;

            chart1.Series.Clear();
            if (endDate == startDate)
            {
                DateTime currentDate = startDate;
                // Tạo một series mới cho mỗi ngày
                Series daySeries = new Series(currentDate.ToString("dd-MM-yyyy"));
                daySeries.ChartType = SeriesChartType.Column;

                // Gọi hàm từ BUS để lấy doanh thu cho ngày hiện tại
                float dailyRevenue = billBus.GetAllBillChart(currentDate);

                // Thêm điểm dữ liệu vào series mới
                daySeries.Points.AddXY(currentDate.ToString("dd-MM-yyyy"), dailyRevenue);
                // Thêm series mới vào Chart
                chart1.Series.Add(daySeries);
                chart1.ChartAreas[0].AxisX.Interval = 1;
                chart1.Series[currentDate.ToString("dd-MM-yyyy")].IsValueShownAsLabel = true;
                chart1.Visible = true;
                var oder = billBus.GetAllBillGrid(dtpkFromDate.Value, dtpkToDate.Value);
                DataGridView1.DataSource = oder;
            }
            else if (endDate > startDate)
            {
                for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
                {
                    // Tạo một series mới cho mỗi ngày
                    Series daySeries = new Series(currentDate.ToString("dd-MM-yyyy"));
                    daySeries.ChartType = SeriesChartType.Column;

                    // Gọi hàm từ BUS để lấy doanh thu cho ngày hiện tại
                    float dailyRevenue = billBus.GetAllBillChart(currentDate);

                    // Thêm điểm dữ liệu vào series mới
                    daySeries.Points.AddXY(currentDate.ToString("dd-MM-yyyy"), dailyRevenue);

                    // Thêm series mới vào Chart
                    chart1.Series.Add(daySeries);
                    chart1.ChartAreas[0].AxisX.Interval = 1;
                    chart1.Series[currentDate.ToString("dd-MM-yyyy")].IsValueShownAsLabel = true;
                }
                chart1.Visible = true;
                var oder = billBus.GetAllBillGrid(dtpkFromDate.Value, dtpkToDate.Value);
                DataGridView1.DataSource = oder;
            }
            else
            {
                MessageBox.Show("Start Date must be less or equal than End Date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Events
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            loadListBillbyDate(dtpkFromDate.Value, dtpkToDate.Value);
            UpdateChart();
        }
        #endregion


        private void dtgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
