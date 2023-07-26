namespace DTO
{
    public class DTO_HoaDon
    {
        private int employeeId;

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }
        private int customerId;

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        private double totalPrice;

        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public DTO_HoaDon()
        {
        }

        public DTO_HoaDon(int employeeId, int customerId, double totalPrice)
        {
            this.EmployeeId = employeeId;
            this.CustomerId = customerId;
            this.TotalPrice = totalPrice;
        }


    }
}
