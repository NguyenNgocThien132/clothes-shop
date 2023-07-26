using BUS;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmGuiMail : Form
    {
        private string result;

        public string Result
        {
            get { return result; }
            set { result = value; }
        }
        private string email; // email cần gửi tin
        private string password; // mật khẩu đăng nhập phần mềm
        private bool isUpdate;

        public frmGuiMail(string email, string pass, bool isUpdate = false)
        {
            InitializeComponent();
            this.email = email;
            this.password = pass;
            this.isUpdate = isUpdate;
        }          
        private void SendMail_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(Send);
            thread.IsBackground = true;
            thread.Start();
        }

        private void Send()
        {
            string loginEmail = "shopbanquanaonhom10@gmail.com";
            string loginPassword = "shopbanquanao123";
            BUS_Mail mail = new BUS_Mail(loginEmail, loginPassword);
            Result = mail.SendMail(email, password, isUpdate);
            pcbLoader.Invoke(new Action(() => Close()));
        } 
    }
}
