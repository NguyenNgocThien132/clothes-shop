using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_HoaDon
    {
        DAL_HoaDon dalBill = new DAL_HoaDon();

        public DataTable ListOfBills()
        {
            return dalBill.ListOfBills();
        }

        public bool InsertBill(DTO_HoaDon bill)
        {
            return dalBill.InsertBill(bill);
        }

        public DataTable SearchCustomerInBill(string name)
        {
            return dalBill.SearchCustomerInBill(name);
        }

        public double GetRevenueInJan()
        {
            return dalBill.GetRevenueInJan();
        }
        //public double GetRevenueInFeb()
        //{
        //    return dalBill.GetRevenueInFeb();
        //}
        public double GetRevenueInMar()
        {
            return dalBill.GetRevenueInMar();
        }
        public double GetRevenueInApr()
        {
            return dalBill.GetRevenueInApr();
        }
        public double GetRevenueInMay()
        {
            return dalBill.GetRevenueInMay();
        }
        public double GetRevenueInJune()
        {
            return dalBill.GetRevenueInJune();
        }

        public double GetRevenueInJuly()
        {
            return dalBill.GetRevenueInJuly();
        }
        public double GetRevenueInAug()
        {
            return dalBill.GetRevenueInAug();
        }
        public double GetRevenueInSep()
        {
            return dalBill.GetRevenueInSep();
        }
        public double GetRevenueInOct()
        {
            return dalBill.GetRevenueInOct();
        }
        public double GetRevenueInNov()
        {
            return dalBill.GetRevenueInNov();
        }
        public double GetRevenueInDec()
        {
            return dalBill.GetRevenueInDec();
        }
    }
}
