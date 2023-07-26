using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BUS
{
    public class BUS_Mail
    {
        private string senderEmail;
        private string senderPassword;

        public BUS_Mail(string senderEmail, string senderPassword)
        {
            this.senderEmail = senderEmail;
            this.senderPassword = senderPassword;
        }

        public string SendMail(string recipientEmail, string recipientPassword, bool isUpdate = false)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();
                mailMsg.From = new MailAddress(senderEmail);
                mailMsg.To.Add(recipientEmail);
                if (isUpdate)
                {
                    mailMsg.Body = "Xin chào bạn, mật khẩu mới truy cập phần mềm của bạn là: " + recipientPassword;
                    mailMsg.Subject = "Bạn đã yêu cầu cấp lại mật khẩu! Đừng quên nữa nhé....";
                }
                else
                {
                    mailMsg.Body = string.Format("Chào mừng bạn đã đến với shop mình, bạn đã được thêm vào danh sách trở thành nhân của phần mềm 'Shopbanquanao-nhom4' với " +
                                                 "thông tin đăng nhập là: \n- Email: {0} \n- Mật khẩu: {1} ", recipientEmail, recipientPassword);
                    mailMsg.Subject = "Bạn đã được thêm vào phần mềm của Shop!";
                }
                //SmtpClient System.Net.Mail;
                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderEmail, "yvndgupqyoyriryc");
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(mailMsg);
                }
                return "Gửi tin nhắn thành công, vui lòng kiểm tra email.";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string GetRandomPassword()
        {
            Random r = new Random();
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(r.Next(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random r = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 50)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToUpper();
            }
            else return builder.ToString().ToLower();
        }
    }
}
