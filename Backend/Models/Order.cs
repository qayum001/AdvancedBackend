namespace Backend.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public List<DishInCart>? Dishes{ get; set; }
        public Status Status { get; set; }
    }
}
