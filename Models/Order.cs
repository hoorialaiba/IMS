
namespace IMSIdentity.Models
{
    public class Order
    {
        public int id;
        public DateTime orderDate = DateTime.Now;
        public List<OrderItem> orderItems;
        public decimal totalAmount;
        public string userId;

        public int Id
        {
            get { 
                return id;
            }
            set { 
                id = value;
            }
        }
        public string UserId { 
            get 
            { 
                return userId;
            } 
            set 
            {
                userId = value;
            }
        }
        public DateTime OrderDate
        {
            get { 
                return orderDate; 
            }
            set { 
                orderDate = value;
            }
        }

        public List<OrderItem> OrderItems
        {
            get { 
                return orderItems;
            }
            set { 
                orderItems = value;
            }
        }

        public decimal TotalAmount
        {
            get { 
                return totalAmount;
            }
            set { 
                totalAmount = value;
            }
        }
    }
}
