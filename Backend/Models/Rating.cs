namespace Backend.Models
{
    public class Rating
    {
        public Dish? Dish { get; set; }
        public Customer? Customer { get; set; }
        public double Value { get; set; }
    }
}
