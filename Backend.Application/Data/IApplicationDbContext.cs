using Backend.Domain.Entity.Delivery;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Dish> Dishes { get; }
        DbSet<DishInCart> DishInCart { get; }
        DbSet<Menu> Menues { get; }
        DbSet<Order> Orders { get; }
        DbSet<Rating> Rating { get; }
        DbSet<Restaurant> Restaurants { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
