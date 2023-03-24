namespace Backend.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public List<Rating>? Rating { get; set; }
        public List<Order>? OrderHistory { get; set; }
        public List<Dish>? Dishes { get; set; }
    }
}
