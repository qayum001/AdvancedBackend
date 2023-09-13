using Backend.Domain.Common;
using Backend.Domain.Entity.Users;

namespace Backend.Domain.Entity.Delivery
{
    public class Rating : BaseAuditableEntity
    {
        public Dish Dish { get; private set; } = new Dish();
        public Guid DishID { get; private set; }
        public Customer Customer { get; private set; } = new Customer();
        public Guid CustomerId { get; private set; }
        public double Value { get; private set; }
    }
}