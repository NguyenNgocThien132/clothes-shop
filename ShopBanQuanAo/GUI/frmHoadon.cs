using BUS;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmHoadon : Form
    {
        frmChitietHoaDon fBillInfo;
        BUS_HoaDon busBill = new BUS_HoaDon();

        public frmHoadon(string email)
        {
            InitializeComponent();
            fBillInfo = new frmChitietHoaDon(email);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            fBillInfo.ShowDialog();
            this.Show();
            gvBill.DataSource = busBill.ListOfBills();
            LoadGridView();
        }

        private void LoadGridView()
        {
            gvBill.Columns[0].HeaderText = "Mã HD";
            gvBill.Columns[1].HeaderText = "Tên KH";
            gvBill.Columns[2].HeaderText = "Thời gian";
            gvBill.Columns[3].HeaderText = "Tổng tiền";
            foreach (DataGridViewColumn item in gvBill.Columns)
            {
                item.DividerWidth = 1;
            }
            gvBill.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvBill.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvBill.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvBill.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvBill.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        //Tìm kiếm khách hàng
        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            string name = txtSearch.Text.Trim();

            if (name == "")
            {
                frmBill_Load(sender, e);
                txtSearch.Focus();
            }
            else
            {
                DataTable data = busBill.SearchCustomerInBill(txtSearch.Text);
                gvBill.DataSource = data;
            }
        }
        // Load dữ liệu
        private void frmBill_Load(object sender, EventArgs e)
        {
            gvBill.DataSource = busBill.ListOfBills();
            LoadGridView();
        }

        private void btn_in_Click(object sender, EventArgs e)
        {
            
        }
    }
}
