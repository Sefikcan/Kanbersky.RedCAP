using Kanbersky.RedCAP.Infrastracture.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kanbersky.RedCAP.Infrastracture.DataAccess.EntityFramework
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<Entities.Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
