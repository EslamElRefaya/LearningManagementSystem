using LearningManagementSystem.Domain.Events;

namespace Learning_Management_System.Domain.DomainEvents
{
    public class CoursePublishedEvent : IDomainEvent
    {
        public Guid CourseId { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public CoursePublishedEvent(Guid courseId)
        {
            CourseId = courseId;
        }
    }

}
