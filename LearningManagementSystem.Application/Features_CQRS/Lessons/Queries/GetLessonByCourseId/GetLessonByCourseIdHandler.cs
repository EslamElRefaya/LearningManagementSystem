using LearningManagementSystem.Application.DTOs.Lessons;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Lessons.Queries.GetLessonByCourseId
{
    public class GetLessonByCourseIdHandler : IRequestHandler<GetLessonByCourseIdQuery, List<DetailsLessonDto>>
    {
        private readonly ILessonRepository _lessonRepository;

        public GetLessonByCourseIdHandler(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<List<DetailsLessonDto>> Handle(GetLessonByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var lesson=await _lessonRepository.GetLessonByCourseIdAsync(request.CourseId);
            if (lesson == null)
               throw new KeyNotFoundException("Lesson not found");
            return  lesson.Adapt<List<DetailsLessonDto>>();
        }
    }
}
