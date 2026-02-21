using LearningManagementSystem.Domain.Enums;
using MediatR;
namespace LearningManagementSystem.Application.Features_CQRS.Lessons.Commands.CreateLesson
{
    public record CreateLessonCommand
        (
            string Title,
            LessonType LessonType,
            int Order,
            Guid CourseId
        ) : IRequest<Unit>;
}
