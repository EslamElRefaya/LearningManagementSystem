using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;
namespace LearningManagementSystem.Application.Features_CQRS.Lessons.Commands.CreateLesson
{
    public class CreateLessonHandler : IRequestHandler<CreateLessonCommand, Unit>
    {
        private readonly ILessonRepository _lessonRepository;
        public CreateLessonHandler(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<Unit> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            if(request is null)
            {
                throw new ArgumentException();
            }
            var lesson = request.Adapt<Lesson>();
            await _lessonRepository.AddAsync(lesson);
            return Unit.Value;
        }
    }
}
