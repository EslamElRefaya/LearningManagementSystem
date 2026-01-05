namespace LearningManagementSystem.Domain.Events
{
   public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
