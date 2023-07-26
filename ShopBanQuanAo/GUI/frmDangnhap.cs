using BUS;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDangnhap : Form
    {
        BUS_NhanVien busEmployee = new BUS_NhanVien();

        public frmDangnhap()
        {
            InitializeComponent();
        }

        // Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtPassword.Text != "")
            {

                if (busEmployee.Login(txtEmail.Text, txtPassword.Text))
                {
                    Properties.Settings.Default.isSave = tglRememberMe.Checked;
                    if (tglRememberMe.Checked)
                    {
                        Properties.Settings.Default.email = txtEmail.Text;
                        Properties.Settings.Default.password = txtPassword.Text;
                    }
                    Properties.Settings.Default.Save();
                    frmMain fMain = new frmMain(txtEmail.Text);
                    MessageBox.Show("CHÀO MỪNG BẠN ĐÃ ĐĂNG NHẬP VÀO SHOP!!!");
                    this.Hide();
                    fMain.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai email hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                    txtEmail.Focus();
                }
            }
        }
        // Load dữ liệu
        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.isSave)
            {
                string srtmail = txtEmail.Text.Trim();
                string strpass = txtPassword.Text.Trim();
                srtmail = Properties.Settings.Default.email;
                strpass = Properties.Settings.Default.password;
                tglRememberMe.Checked = true;
            }
        }

        // Gửi lại mk vào email cho nhân viên quên
        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                busEmployee = new BUS_NhanVien();
                if (busEmployee.IsExistEmail(txtEmail.Text))
                {
                    string password = busEmployee.GetRandomPassword();
                    if (busEmployee.UpdatePassword(txtEmail.Text, password))
                    {
                        frmGuiMail loader = new frmGuiMail(txtEmail.Text, password, true);
                        loader.ShowDialog();
                        MessageBox.Show(loader.Result, "Thông báo");
                    }
                    else
                        MessageBox.Show("Không thực hiện được", "Thông báo");
                }
            }
        }

    }
}
