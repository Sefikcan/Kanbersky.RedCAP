using Kanbersky.RedCAP.Core.Infrastructure.Abstract;
using Kanbersky.RedCAP.Core.Infrastructure.Abstract.EntityFramework;

namespace Kanbersky.RedCAP.Infrastracture.Entities
{
    public class OrderItem : BaseEntity, IEntity
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
