using Backend.Domain.Common;
using Backend.Domain.Common.Enums;

namespace Backend.Domain.Entity.Delivery
{
    public class Order : BaseAuditableEntity
    {
        public DateTime DeliveryTime { get; private set; }
        public DateTime OrderTime { get; private set; }
        public decimal Price { get; private set; }
        public string Address { get; private set; } = string.Empty;
        public OrderStatus Status { get; private set; }
        public List<DishInCart> DishInCart { get; private set; } = new List<DishInCart>();
    }
}
