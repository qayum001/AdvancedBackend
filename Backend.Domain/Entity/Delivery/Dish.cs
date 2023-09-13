using Backend.Domain.Common;
using Backend.Domain.Common.Enums;

namespace Backend.Domain.Entity.Delivery
{
    public class Dish : BaseAuditableEntity
    {
        public List<Menu> Menues { get; private set; } = new List<Menu>();
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public bool IsVegetarian { get; private set; }
        public string PhotoUrl { get; private set; } = string.Empty;
        public FoodCategory FoodCategory { get; private set; }
    }
}
