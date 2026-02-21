using LearningManagementSystem.Application.DTOs.Lessons;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Lessons.Queries.GetLessonById
{
    public class GetLessonByIdQuery : IRequest<DetailsLessonDto>
    {
        public Guid LessonId { get; set; }
        public GetLessonByIdQuery(Guid lessonId)
        {
            LessonId = lessonId;
        }

     
    }
}
