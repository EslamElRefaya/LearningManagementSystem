using LearningManagementSystem.Domain.Events;

namespace LearningManagementSystem.Domain.Interfaces.Services
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(IDomainEvent domainEvent);
    }

}
