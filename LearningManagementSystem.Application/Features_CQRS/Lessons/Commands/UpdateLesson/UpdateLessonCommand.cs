using LearningManagementSystem.Application.DTOs.Lessons;
using LearningManagementSystem.Domain.Enums;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Lessons.Commands.UpdateLesson
{
    public record UpdateLessonCommand(
        Guid lessonId,
        UpdateLessonDto updateLessonDto
    ) : IRequest<Unit>;
}
