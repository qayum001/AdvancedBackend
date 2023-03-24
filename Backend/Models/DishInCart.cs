namespace Backend.Models
{
    public class DishInCart
    {
        public Dish? Dish { get; set; }
        public int Count { get; set; } = 1;
    }
}
