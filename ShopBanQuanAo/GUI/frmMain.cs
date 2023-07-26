using BUS;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMain : Form
    {
        BUS_NhanVien busEmployee = new BUS_NhanVien();

        frmTrangchu fHome = new frmTrangchu();
        frmNhanvien fEmployee = new frmNhanvien();
        frmSanPham fProduct = new frmSanPham();
        frmKhachHang fCustomer = new frmKhachHang();
        frmDanhThu fStatistic = new frmDanhThu();
        frmTaiKhoan fAccount;
        frmHoadon fBill;

        public frmMain(string email)
        {
            InitializeComponent();

            // Kiểm tra Vai trò của nhân viên

            if (!busEmployee.GetEmployeeRole(email))
            {
                btnEmployee.Visible = false;
                btnStatistic.Visible = false;
                btnhome.Checked = true;
                //fProduct.TopLevel = false;
                //fProduct.Dock = DockStyle.Fill;
                //pnlBody.Controls.Add(fProduct);
                //fProduct.Show(); // Nếu vai trò là nhân viên thì hiển thị sản phẩm 
                fHome.TopLevel = false;
                pnlBody.Controls.Add(fHome);
                fHome.Dock = DockStyle.Fill;
                fHome.Show();
            }
            else
            {
                btnhome.Checked = true;
                //fStatistic.TopLevel = false;
                //fStatistic.Dock = DockStyle.Fill;
                //pnlBody.Controls.Add(fStatistic);
                //fStatistic.Show(); // Nếu vai trò là admin thì hiển thị thống kê sản phẩm qua các tháng

                fHome.TopLevel = false;
                pnlBody.Controls.Add(fHome);
                fHome.Dock = DockStyle.Fill;
                fHome.Show();

            }
            //Khởi tạo form accout và Bill
            fAccount = new frmTaiKhoan(email);
            fBill = new frmHoadon(email);
        }
        // Thoát luôn
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // đăng xuất
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Load from Employee
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fEmployee.TopLevel = false;
            fEmployee.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fEmployee);
            fEmployee.Show();
        }
        // Load from Product
        private void btnProduct_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fProduct.TopLevel = false;
            pnlBody.Controls.Add(fProduct);
            fProduct.Dock = DockStyle.Fill;
            fProduct.Show();
        }
        // Load from Customer
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fCustomer.TopLevel = false;
            pnlBody.Controls.Add(fCustomer);
            fCustomer.Dock = DockStyle.Fill;
            fCustomer.Show();
        }
        // Load from Bill
        private void btnBill_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fBill.TopLevel = false;
            pnlBody.Controls.Add(fBill);
            fBill.Dock = DockStyle.Fill;
            fBill.Show();
        }

        // Load from Account
        private void btnAccount_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fAccount.TopLevel = false;
            pnlBody.Controls.Add(fAccount);
            fAccount.Dock = DockStyle.Fill;
            fAccount.Show();
        }
        // Hiển thị thống kê thu nhập 
        private void btnStatistic_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fStatistic.TopLevel = false;
            pnlBody.Controls.Add(fStatistic);
            fStatistic.Dock = DockStyle.Fill;
            fStatistic.Show();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            fHome.TopLevel = false;
            pnlBody.Controls.Add(fHome);
            fHome.Dock = DockStyle.Fill;
            fHome.Show();
            
        }
    }
}
