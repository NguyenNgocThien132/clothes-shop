namespace DTO
{
    public class DTO_NhanVien
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private bool role;

        public bool Role
        {
            get { return role; }
            set { role = value; }
        }
        private bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public DTO_NhanVien()
        {
        }
        public DTO_NhanVien(string name, string address, string phoneNumber, string email, bool role, bool status, string password)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.role = role;
            this.status = status;
            this.password = password;
        }
        public DTO_NhanVien(string name, string address, string phoneNumber, string email, bool role, bool status)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.role = role;
            this.status = status;
        }
        public DTO_NhanVien(string address, string phoneNumber, string email)
        {
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
        
    }
}
