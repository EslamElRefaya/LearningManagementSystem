using LearningManagementSystem.Application.DTOs.Lessons;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Lessons.Queries.GetLessonByLessonType
{
    public class GetLessonByLessonTypeHandler : IRequestHandler<GetLessonByLessonTypeQuery, List<DetailsLessonDto>>
    {
        private readonly ILessonRepository _lessonRepository;

        public GetLessonByLessonTypeHandler(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<List<DetailsLessonDto>> Handle(GetLessonByLessonTypeQuery request, CancellationToken cancellationToken)
        {
            var lesson = await _lessonRepository.GetLessByLessonTypeAsync(request.LessonType);
            return lesson.Adapt<List<DetailsLessonDto>>();
        }
    }
}
