using Microsoft.EntityFrameworkCore;

namespace IMSIdentity.Models
{
    public class MyAppDBContext: DbContext
    {
        public MyAppDBContext(DbContextOptions<MyAppDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=hmh;Integrated Security=True;");
            }
        }

    }
}
