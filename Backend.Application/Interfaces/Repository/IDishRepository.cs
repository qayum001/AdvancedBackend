using Backend.Domain.Entity.Delivery;

namespace Backend.Application.Interfaces.Repository
{
    public interface IDishRepository
    {
        Task<List<Dish>> GetMenuDishes(Guid menuId);
        //any necessary methods
    }
}