namespace Backend.Models
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Menu>? Menu { get; set; }
        public List<Manager>? Manager { get; set; }
        public List<Cook>? Cooks { get; set; }
        public OrderHolder? OrderHolder { get; set; }
    }
}
