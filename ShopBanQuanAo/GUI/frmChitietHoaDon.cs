using BUS;
using DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmChitietHoaDon : Form
    {
        BUS_KhachHang busCustomer = new BUS_KhachHang();
        BUS_SanPham busProduct = new BUS_SanPham();
        BUS_NhanVien busEmployee = new BUS_NhanVien();
        BUS_ChiTietHoaDon busBillInfo = new BUS_ChiTietHoaDon();
        BUS_HoaDon busBill = new BUS_HoaDon();
        DTO_ChiTietHoaDon dtoBillInfo;
        DTO_HoaDon dtoBill;

        private string[] listCustomerIdName, listProductNameQuantity;
        private DateTime dateTime = new DateTime();
        private string productName, email, str;
        private char separator = '|';
        private string[] strlist;

        public frmChitietHoaDon(string email)
        {
            InitializeComponent();
            this.email = email;
        }
        // load dữ liệu 
        private void LoadData()
        {
            listCustomerIdName = busCustomer.ListCustomerIdName();
            cboCustomerIdName.Items.Clear();

            foreach (string item in listCustomerIdName)
            {
                cboCustomerIdName.Items.Add(item);
            }
            // lấy thời gian hiện tại
            dateTime = DateTime.Now;
            txtDateTime.Text = dateTime.ToString("dd/MM/yyyy") + " " + dateTime.ToString("HH:mm"); // định dạnh ngày/tháng/năm

            listProductNameQuantity = busProduct.ListProductNameQuantity();
            cboProductNameQuantity.Items.Clear();
            foreach (string item in listProductNameQuantity)
            {
                cboProductNameQuantity.Items.Add(item);
            }

            txtEmployeeIdName.Text = busEmployee.GetEmployeeIdName(email);
        }
        // Hàm thông báo
        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadGridView()
        {
            gvBillInfo.Columns[0].HeaderText = "Mã SP";
            gvBillInfo.Columns[1].HeaderText = "Tên SP";
            gvBillInfo.Columns[2].HeaderText = "Số lượng";
            gvBillInfo.Columns[3].HeaderText = "Thành tiền";
            foreach (DataGridViewColumn item in gvBillInfo.Columns)
            {
                item.DividerWidth = 1;
            }

            gvBillInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvBillInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvBillInfo.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvBillInfo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvBillInfo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        //Thêm chi tiết hóa đơn
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                str = cboProductNameQuantity.SelectedItem.ToString();
                strlist = str.Split(separator);
                productName = strlist[0].Trim();

                if (txtQuantity.Text != "" && cboCustomerIdName.SelectedIndex != -1 &&
                    cboProductNameQuantity.SelectedIndex != -1)
                {
                    dtoBillInfo = new DTO_ChiTietHoaDon
                    (
                        busProduct.GetProductId(productName),
                        int.Parse(txtQuantity.Text),
                        double.Parse(txtUnitPrice.Text)
                    );

                    if (busBillInfo.InsertBillInfo(dtoBillInfo, int.Parse(txtQuantity.Text)))
                    {
                        listProductNameQuantity = busProduct.ListProductNameQuantity();
                        
                            gvBillInfo.DataSource = busBillInfo.ListBillInfo();
                            LoadGridView();
                            txtTotalPrice.Text = busBillInfo.GetTotalPrice().ToString();
                            MsgBox("Thêm hóa đơn thành công");                     
                    }
                    else
                        MsgBox("Thêm không thành công", true);
                }
                else
                    MsgBox("Vui lòng kiểm tra lại dữ liệu", true);
            }
            catch
            {
                MsgBox("Thêm không thành công", true);
            }
        }
        // Load dữ liệu lên form
        private void frmBillInfo_Load(object sender, EventArgs e)
        {
            txtQuantity.Text = null;
            txtUnitPrice.Text = null;
            txtTotalPrice.Text = null;
            LoadData();
            gvBillInfo.DataSource = busBillInfo.ListBillInfo();
            LoadGridView();
        }

        // cập nhập ct hóa đơn
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = busProduct.GetProductId(productName);
            str = cboProductNameQuantity.SelectedItem.ToString();
            strlist = str.Split(separator);
            if (busBillInfo.UpdateProductInBillInfo(id, int.Parse(txtQuantity.Text)))
            {
                gvBillInfo.DataSource = busBillInfo.ListBillInfo();
                LoadGridView();
                txtTotalPrice.Text = busBillInfo.GetTotalPrice().ToString();
                MsgBox("Sửa sản phẩm thành công!");
            }
            else
            {
                MsgBox("Sửa sản phẩm không được", true);
            }
        }

        // Xóa ct hóa đơn
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = busProduct.GetProductId(productName);
            if (MessageBox.Show("Bạn có chắc muốn xóa", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (busBillInfo.DeleteProductInBillInfo(id))
                {
                    MsgBox("Xóa thành công");
                    LoadData();
                    gvBillInfo.DataSource = busBillInfo.ListBillInfo();
                    LoadGridView();
                }
                else
                    MsgBox("Không xóa được", true);
            }
        }

        

        // Thanh toán hóa đơn
        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                str = txtEmployeeIdName.Text;
                strlist = str.Split(separator);
                string employeeId = strlist[0].Trim();

                str = cboCustomerIdName.SelectedItem.ToString();
                strlist = str.Split(separator);
                string customerId = strlist[0].Trim();

                dtoBill = new DTO_HoaDon
                (
                    int.Parse(employeeId),
                    int.Parse(customerId),
                    double.Parse(txtTotalPrice.Text)
                );
                if (busBill.InsertBill(dtoBill))
                {
                    MsgBox("Thanh toán thành công", false);
                    this.Close();
                }
                else
                    MsgBox("Thanh toán không thành công", true);
            }
            catch
            {
                MsgBox("", true);
            }

        }
        // Đổ dữ liệu sản phẩm vào cbb sản phẩm
        private void cboProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = cboProductNameQuantity.SelectedItem.ToString();
            char separator = '|';
            String[] strlist = str.Split(separator);
            productName = strlist[0].Trim();
            txtUnitPrice.Text = busProduct.GetUnitPrice(productName).ToString();
        }
        // thiết lặp lại ban đầu các thao tác
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = null;
            txtUnitPrice.Text = null;
            txtTotalPrice.Text = null;
            LoadData();
        }
    }
}
