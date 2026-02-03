namespace IMSIdentity.Models
{
    public class OrderItem
    {
        private int id;
        private int productId;
        private Product product;
        private int quantity;
        private decimal price;


        public int Id
        {
            get { 
                return id;
            }
            set { 
                id = value;
            }
        }

        public int ProductId
        {
            get { 
                return productId;
            }
            set { 
                productId = value;
            }
        }

        public Product Product
        {
            get { 
                return product;
            }
            set { 
                product = value;
            }
        }

        public int Quantity
        {
            get { 
                return quantity;
            }
            set { 
                quantity = value;
            }
        }

        public decimal Price
        {
            get { 
                return price;
            }
            set { 
                price = value;
            }
        }

    }
}
