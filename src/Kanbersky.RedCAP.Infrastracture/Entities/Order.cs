using Kanbersky.RedCAP.Core.Infrastructure.Abstract;
using Kanbersky.RedCAP.Core.Infrastructure.Abstract.EntityFramework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanbersky.RedCAP.Infrastracture.Entities
{
    public class Order : BaseEntity, IEntity
    {
        public Order()
        {
            OrderItems = new Collection<OrderItem>();
        }

        public decimal OrderTotal { get; set; }

        [ForeignKey("OrderId")]
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
