using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_ChiTietHoaDon
    {
        DAL_ChiTietHoaDon dalBillInfo = new DAL_ChiTietHoaDon();

        public DataTable ListBillInfo()
        {
            return dalBillInfo.ListBillInfo();
        }

        public bool InsertBillInfo(DTO_ChiTietHoaDon billInfo, int quantity)
        {
            return dalBillInfo.InsertBillInfo(billInfo, quantity);
        }

        public double GetTotalPrice()
        {
            return dalBillInfo.GetTotalPrice();
        }

        public bool DeleteProductInBillInfo(int id)
        {
            return dalBillInfo.DeleteProductInBillInfo(id);
        }

        public bool UpdateProductInBillInfo(int id, int quantity)
        {
            return dalBillInfo.UpdateProductInBillInfo(id, quantity);
        }
    }
}
