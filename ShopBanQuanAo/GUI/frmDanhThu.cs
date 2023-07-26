using BUS;
using Guna.Charts.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDanhThu : Form
    {
        BUS_HoaDon busBill = new BUS_HoaDon();

        public frmDanhThu()
        {
            InitializeComponent();
        }

        private void chtImportProduct_Load(object sender, EventArgs e)
        {
            Bar(chtImportProduct);
        }

        public void Bar(GunaChart chart)
        {
            //Cấu hình biểu đồ
            chart.YAxes.GridLines.Display = false;
            //Tạo dữ liệu mới
            var dataset = new GunaBarDataset();
            dataset.DataPoints.Add("Tháng 1", busBill.GetRevenueInJan());
            //dataset.DataPoints.Add("Tháng 2", busBill.GetRevenueInFeb());
            dataset.DataPoints.Add("Tháng 3", busBill.GetRevenueInMar());
            dataset.DataPoints.Add("Tháng 4", busBill.GetRevenueInApr());
            dataset.DataPoints.Add("Tháng 5", busBill.GetRevenueInMay());
            dataset.DataPoints.Add("Tháng 6", busBill.GetRevenueInJune());
            dataset.DataPoints.Add("Tháng 7", busBill.GetRevenueInJuly());
            dataset.DataPoints.Add("Tháng 8", busBill.GetRevenueInAug());
            dataset.DataPoints.Add("Tháng 9", busBill.GetRevenueInSep());
            dataset.DataPoints.Add("Tháng 10", busBill.GetRevenueInOct());
            dataset.DataPoints.Add("Tháng 11", busBill.GetRevenueInNov());
            dataset.DataPoints.Add("Tháng 12", busBill.GetRevenueInDec());

            // Thêm tập dữ liệu mới vào biểu đồ.Datasets
            chart.Datasets.Add(dataset);
            // Một bản cập nhật đã được thực hiện để hiển thị lại biểu đồ
            chart.Update();
        }
        public void Barload(GunaChart chart)
        {
            //Cấu hình biểu đồ
            chart.YAxes.GridLines.Display = false;
            chart.Title.Text = "Doanh thu theo tháng";
            chart.Update();
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            Barload(chtImportProduct);
        }
    }
}
