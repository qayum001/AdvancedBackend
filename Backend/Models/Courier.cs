namespace Backend.Models
{
    public class Courier
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Order? CurrentOrder { get; set; }
        public List<Order>? OrdersHistory { get; set; }
    }
}
