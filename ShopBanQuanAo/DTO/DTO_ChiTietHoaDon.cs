namespace DTO
{
    public class DTO_ChiTietHoaDon
    {
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
     
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        private double unitPrice;

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        public DTO_ChiTietHoaDon()
        {

        }
        public DTO_ChiTietHoaDon(int productId,int quantity, double unitPrice)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }
       
    }
}
