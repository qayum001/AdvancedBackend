namespace Backend.Models
{
    public class Manager
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
