using LearningManagementSystem.Domain.Interfaces.Repositories;
using MediatR;
namespace LearningManagementSystem.Application.Features_CQRS.Lessons.Commands.DeleteLesson
{
    public class DeleteLessonHandler:IRequestHandler<DeleteLessonCommand, Unit>
    {
        private readonly ILessonRepository _lessonRepository;
        public DeleteLessonHandler(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }
        public async Task<Unit> Handle(DeleteLessonCommand request,CancellationToken cancellationToken)
        {
            var lesson = await _lessonRepository.GetByIdAsync(request.LessonId)
                         ?? throw new KeyNotFoundException("Lesson not found.");

            await _lessonRepository.DeleteAsync(lesson);
            return Unit.Value;
        }
    }
}
