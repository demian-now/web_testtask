using System.Data.Entity;

namespace TestTaskWeb
{
    public class OrderContext: DbContext
    {
        public OrderContext()
            : base("DbConnection")
        { }

        public DbSet<Order> Orders { get; set; }
    }
}
