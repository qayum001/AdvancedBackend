namespace Backend.Domain.Common.Interfaces
{
    public interface IAuditableEntity : IEntity
    {
        Guid CreatedBy { get; }
        DateTime CreatedDate { get; }
        Guid UpdatedBy { get; }
        DateTime UpdatedDate { get; }
    }
}