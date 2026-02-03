namespace IMSIdentity.Models
{
    public class CartItem
    {
        public int id;
        public int productId;
        public Product product;
        public int quantity;
        public string userId;// <-- This is needed

        public string UserId 
        {
            get 
            {
                return userId;
            }
            set 
            {
                userId = value;
            }
        }   // <-- This is needed
        public int Id { 
            get 
            {
                return id;
            }
            set 
            {
                id = value;
            }
        }
        public int ProductId {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }
        public Product Product {
            get
            {
                return product;
            }
            set
            {
                product = value;
            }
        }

        public int Quantity {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }
    }
}
