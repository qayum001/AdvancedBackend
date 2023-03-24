namespace Backend.Models
{
    public class Cook
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Restaurant? Restaurant { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
