using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Courses.Commands.PublishCourse
{
    public record PublishCourseCommand(Guid CourseId) : IRequest<Unit>;
}
