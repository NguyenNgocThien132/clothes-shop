using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dalCustomer = new DAL_KhachHang();

        public DataTable ListOfCustomers()
        {
            return dalCustomer.ListOfCustomers();
        }

        public bool InsertKhachHang(DTO_KhachHang customer)
        {
            return dalCustomer.InsertCustomer(customer);
        }

        public bool DeleteKhachHang(int id)
        {
            return dalCustomer.DeleteCustomer(id);
        }

        public bool UpdateCustomer(DTO_KhachHang customer)
        {
            return dalCustomer.UpdateCustomer(customer);
        }

        public DataTable SearchCustomer(string name)
        {
            return dalCustomer.SearchCustomer(name);
        }

        public string[] ListCustomerIdName()
        {
            return dalCustomer.ListCustomerIdName();
        }
      
    }
}
