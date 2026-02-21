using LearningManagementSystem.Application.Contracts.Persistence;
using LearningManagementSystem.Application.DTOs.Lessons;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Lessons.Queries.GetAllLessons
{
    public class GetAllLessonsQueryHandler
        : IRequestHandler<GetAllLessonsQuery, List<DetailsLessonDto>>
    {
        private readonly ILessonRepository _lessonRepository;

        public GetAllLessonsQueryHandler(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<List<DetailsLessonDto>> Handle(
            GetAllLessonsQuery request,
            CancellationToken cancellationToken)
        {

            var lessons= await _lessonRepository.GetAllAsync();
            return lessons.Adapt<List<DetailsLessonDto>>();
        }
    }
}