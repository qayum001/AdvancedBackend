namespace Backend.Models
{
    public class Dish
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool? IsVegetarian { get; set; }
        public List<Menu>? Menu { get; set; }
        public List<Rating>? Rating { get; set; }
        public List<Customer>? Customers { get; set; }
        public Category Category { get; set; }
    }
}