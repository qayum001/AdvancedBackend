using Backend.Domain.Common;
using System.Security.Cryptography.X509Certificates;

namespace Backend.Domain.Entity.Delivery
{
    public class Menu : BaseAuditableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public Restaurant Restaurant { get; private set; } = new Restaurant();
        public Guid RestaurantId { get; private set; } 
        public List<Dish> Dishes { get; private set; } = new List<Dish>();
        public string ImageUrl { get; private set; } = string.Empty;

        public Menu(Guid createdBy, string name, Restaurant restaurant, Guid restaurantId, string imageUrl)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreatedBy = createdBy;
            CreatedDate = DateTime.Now;
            Restaurant = restaurant;
            RestaurantId = restaurantId;
            ImageUrl = imageUrl;
        }

        public async Task Rename(string name, Guid updatedBy)
        {
            Name = name;
            await Update(updatedBy);
        }
    }
}
