namespace IMSIdentity.Models
{
    public class Alert
    {
        public int id;
        public string title;
        public string message;
        public string iconClass;
        public DateTime createdAt;
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
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Message {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
        public string IconClass {
            get
            {
                return iconClass;
            }
            set
            {
                iconClass = value;
            }
        }
        public DateTime CreatedAt {
            get
            {
                return createdAt;
            }
            set
            {
                createdAt = value;
            }
        }
    }
}
