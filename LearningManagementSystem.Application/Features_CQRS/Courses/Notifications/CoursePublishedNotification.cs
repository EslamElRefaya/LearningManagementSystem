using MediatR;
namespace LearningManagementSystem.Application.Features_CQRS.Courses.Notifications
{
    // Notification Layer -> Can make multiple Handlers
    public record CoursePublishedNotification(Guid CourseId, string Title) : INotification;

}
