using MediatR;
using LearningManagementSystem.Application.Features_CQRS.Courses.Notifications;

namespace LearningManagementSystem.Application.Features_CQRS.Courses.EventHandlers
{
    public class SendEmailOnCoursePublishedHandler : INotificationHandler<CoursePublishedNotification>
    {
        public Task Handle(CoursePublishedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[Email] Course Published: {notification.Title}");
            return Task.CompletedTask;
        }
    }

    public class LogCoursePublishedHandler : INotificationHandler<CoursePublishedNotification>
    {
        public Task Handle(CoursePublishedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[Log] Course Published: {notification.Title}");
            return Task.CompletedTask;
        }
    }
}
