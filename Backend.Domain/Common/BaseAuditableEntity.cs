using Backend.Domain.Common.Interfaces;

namespace Backend.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
    {
        public Guid CreatedBy { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public Guid UpdatedBy { get; protected set; }
        public DateTime UpdatedDate { get; protected set; }

        public Task Update(Guid id)
        {
            UpdatedBy = id;
            UpdatedDate = DateTime.Now;
            return Task.CompletedTask;
        }
    }
}