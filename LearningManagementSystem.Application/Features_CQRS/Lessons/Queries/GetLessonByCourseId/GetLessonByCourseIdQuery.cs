using LearningManagementSystem.Application.DTOs.Lessons;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Lessons.Queries.GetLessonByCourseId
{
    public class GetLessonByCourseIdQuery : IRequest<List<DetailsLessonDto>>
    {
        public Guid CourseId { get; set; }
        public GetLessonByCourseIdQuery(Guid courseId)
        {
            CourseId = courseId;
        }  
    }
    //public record GetLessonByCourseIdQuery
    //    (Guid CourseId) : IRequest<List<DetailsLessonDto>>;

}
