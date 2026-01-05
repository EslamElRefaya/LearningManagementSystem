using LearningManagementSystem.Domain.Events;

namespace LearningManagementSystem.Domain.DomainEvents
{
    public class CertificateIssuedEvent : IDomainEvent
    {
        public Guid UserId { get; }
        public Guid CourseId { get; }

        public DateTime OccurredOn => throw new NotImplementedException();

        public CertificateIssuedEvent(Guid userId, Guid courseId)
        {
            UserId = userId;
            CourseId = courseId;
        }
    }
}
