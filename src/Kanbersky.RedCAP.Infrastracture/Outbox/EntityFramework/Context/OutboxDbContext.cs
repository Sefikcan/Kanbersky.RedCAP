using Microsoft.EntityFrameworkCore;

namespace Kanbersky.RedCAP.Infrastracture.Outbox.EntityFramework.Context
{
    public class OutboxDbContext : DbContext
    {
        public OutboxDbContext(DbContextOptions<OutboxDbContext> options) : base(options)
        {
        }
    }
}
