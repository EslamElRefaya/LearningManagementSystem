using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Lessons.Commands.DeleteLesson
{
    public record DeleteLessonCommand(Guid LessonId) : IRequest<Unit>;
}
