namespace IMS.Models
{
    public class Product
    {
        private string name;
        private string brand;
        private int quantity;
        private decimal price;
        private string type;
        private string expiry;
        private string barcode;
        private string description;
        private IFormFile productImage;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public string Expiry
        {
            get
            {
                return expiry;
            }
            set
            {
                expiry = value;
            }
        }

        public string Barcode
        {
            get
            {
                return barcode;
            }
            set
            {
                barcode = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public IFormFile ProductImage
        {
            get
            {
                return productImage;
            }
            set
            {
                productImage = value;
            }
        }
    }
}
