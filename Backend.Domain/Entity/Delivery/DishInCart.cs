using Backend.Domain.Common;
using Backend.Domain.Entity.Users;

namespace Backend.Domain.Entity.Delivery
{
    public class DishInCart : BaseAuditableEntity
    {
        public Dish Dish { get; private set; } = new Dish();
        public Guid DishId { get; private set; }
        public Customer Customer { get; private set; } = new Customer();
        public Guid CustomerId { get; private set; }
    }
}
