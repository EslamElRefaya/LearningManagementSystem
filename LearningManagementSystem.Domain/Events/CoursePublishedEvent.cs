using MediatR;

namespace LearningManagementSystem.Domain.Events
{
    // Domain Event + MediatR Notification
    public record CoursePublishedEvent(
        Guid CourseId,
        string Title
    ) : INotification;
}
