﻿namespace Backend.Models
{
    public class Menu
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Restaurant? Restaurant { get; set; }
        public List<Dish>? Dishes { get; set; }
    }
}
