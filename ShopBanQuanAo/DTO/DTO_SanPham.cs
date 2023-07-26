namespace DTO
{
    public class DTO_SanPham
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
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        private double importUnitPrice;

        public double ImportUnitPrice
        {
            get { return importUnitPrice; }
            set { importUnitPrice = value; }
        }
        private double unitPrice;

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        private byte[] image;

        public byte[] Image
        {
            get { return image; }
            set { image = value; }
        }
        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public DTO_SanPham()
        {
        }

        public DTO_SanPham(string name, int quantity, double importUnitPrice, double unitPrice, byte[] image, string note)
        {
            this.name = name;
            this.quantity = quantity;
            this.importUnitPrice = importUnitPrice;
            this.unitPrice = unitPrice;
            this.image = image;
            this.note = note;
        }

        public DTO_SanPham(int id, string name, int quantity, double importUnitPrice, double unitPrice, byte[] image, string note)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
            this.importUnitPrice = importUnitPrice;
            this.unitPrice = unitPrice;
            this.image = image;
            this.note = note;
        }

        
    }
}
