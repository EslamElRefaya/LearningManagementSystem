using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Lessons.Commands.UpdateLesson
{
    public class UpdateLessonHandler:IRequestHandler<UpdateLessonCommand, Unit>
    {
        private readonly ILessonRepository _lessonRepository;
        public UpdateLessonHandler(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<Unit> Handle(UpdateLessonCommand request,CancellationToken cancellationToken)
        {
            var lesson = await _lessonRepository.GetByIdAsync(request.lessonId)
                         ?? throw new KeyNotFoundException("Lesson not found.");
            // Map DTO → Entity 
            request.updateLessonDto.Adapt(lesson);

            await _lessonRepository.UpdateAsync(lesson);
            return Unit.Value;
        }
    }
}
