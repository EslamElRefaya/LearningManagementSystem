using LearningManagementSystem.Application.DTOs.Lessons;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Lessons.Queries.GetLessonById
{
    public class GetLessonByIdHandler : IRequestHandler<GetLessonByIdQuery, DetailsLessonDto>
    {
        private readonly ILessonRepository _lessonRepository;

        public GetLessonByIdHandler(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<DetailsLessonDto> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
        {
            var lesson=await _lessonRepository.GetByIdAsync(request.LessonId);
            if (lesson == null)
                throw new KeyNotFoundException("Lesson not found");
            return lesson.Adapt<DetailsLessonDto>();
        }
    }
}
