using System.Collections.Generic;
using System.Linq;

namespace Kanbersky.RedCAP.Services.DTO.Request
{
    public class CreateOrderRequestModel
    {
        public decimal OrderTotal
        {
            get
            {
                return OrderItems.Sum(c => c.Quantity * c.Price);
            }
        }

        public List<CreateOrderItemRequestModel> OrderItems { get; set; }
    }

    public class CreateOrderItemRequestModel
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
