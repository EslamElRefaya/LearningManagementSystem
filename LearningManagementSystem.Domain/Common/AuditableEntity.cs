namespace LearningManagementSystem.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }

        public Guid? CreatedBy { get; protected set; }
        public Guid? UpdatedBy { get; protected set; }

        protected AuditableEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public void SetCreated(Guid userId)
        {
            CreatedBy = userId;
        }

        public void SetUpdated(Guid userId)
        {
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = userId;
        }
    }
}
