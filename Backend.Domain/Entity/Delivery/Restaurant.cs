using Backend.Domain.Common;

namespace Backend.Domain.Entity.Delivery
{
    public class Restaurant : BaseAuditableEntity
    {
        public string Name { get; private set; } = string.Empty;

        public List<Menu> Menues { get; private set; } = new List<Menu>();
    }
}
