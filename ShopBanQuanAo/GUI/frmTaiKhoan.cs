using BUS;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTaiKhoan : Form
    {
        BUS_NhanVien busEmployee = new BUS_NhanVien();
        DTO_NhanVien dtoEmployee;
        private string email, str;
        private char separator = '|';
        private string[] strlist;

        public frmTaiKhoan(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void LoadData()
        {
            // gọi hàm lấy ID, Name của  nhân viên in class BUS_Employee
            str = busEmployee.GetEmployeeIdName(email);

            //Tách chuổi và phân cách 
            strlist = str.Split(separator);

            // Gán txtName.text = chuổi vừa tách
            txtName.Text = strlist[1].Trim();

            // gọi hàm lấy địa chỉ, số điện thoại của  nhân viên in class BUS_Employee
            str = busEmployee.GetEmployeeAddressPhoneNumber(email);

            //Tách chuổi và phân cách 
            strlist = str.Split(separator);

            //Gán Address.text = chuổi vừa tách
            txtAddress.Text = strlist[0].Trim();

            //Gán txtPhoneNumber.Text = chuổi vừa tách
            txtPhoneNumber.Text = strlist[1].Trim();

            txtEmail.Text = email;
        }
        // Thay đổi mật khẩu 
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text != "")
            {
                if (txtNewPassword.Text == txtRepeatPassword.Text)
                {
                    busEmployee = new BUS_NhanVien();

                    //Gọi hàm kiểm tra  ChangePassword 
                    if (busEmployee.ChangePassword(txtEmail.Text, txtOldPassword.Text, txtNewPassword.Text))
                    {
                        MessageBox.Show("Đổi mật khẩu thành công, vui lòng đăng nhập lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Properties.Settings.Default.password = "";
                        Properties.Settings.Default.Save();
                        Application.Restart();
                    }
                    else MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Mật khẩu mới không trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Vui lòng nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // Cập nhập tài khoản
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dtoEmployee = new DTO_NhanVien(txtAddress.Text, txtPhoneNumber.Text, txtEmail.Text);

            //Gọi hàm update nhân viên theo địa chỉ, số điện thoại
            if (busEmployee.UpdateEmployeeAddressPhoneNumber(dtoEmployee))
            {
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                MessageBox.Show("Không sửa được thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData(); // thiết lặp lại
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            LoadData(); // Load dữ liệu lên form
        }
    }
}
