using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Courses.Queries.GetCourseById
{
   public class GetCourseByIdQuery: IRequest<DetailsCourseDto>
    {
        public Guid CourseId { get; set; }

        public GetCourseByIdQuery(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}
