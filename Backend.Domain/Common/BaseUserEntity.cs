using Backend.Domain.Common.Enums;

namespace Backend.Domain.Common
{
    public abstract class BaseUserEntity : BaseAuditableEntity
    {
        public Role Role { get; protected set; }
    }
}