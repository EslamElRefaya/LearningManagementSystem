using LearningManagementSystem.Application.DTOs.Lessons;
using LearningManagementSystem.Domain.Enums;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Lessons.Queries.GetLessonByLessonType
{
   public class GetLessonByLessonTypeQuery:IRequest<List<DetailsLessonDto>>
    {
        public LessonType LessonType { get; set; }
        public GetLessonByLessonTypeQuery(LessonType lessonType)
        {
            LessonType = lessonType;
        }
    }
}
