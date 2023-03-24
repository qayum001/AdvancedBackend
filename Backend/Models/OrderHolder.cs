using System.Diagnostics.CodeAnalysis;

namespace Backend.Models
{
    public class OrderHolder
    {
        public Restaurant? Restaurant { get; set; }
        public List<Order>? OrderList { get; set;}
    }
}
