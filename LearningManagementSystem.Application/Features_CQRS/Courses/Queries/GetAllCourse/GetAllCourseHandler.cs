using LearningManagementSystem.Domain.Entities;
using System.Text.RegularExpressions;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using MediatR;
using Mapster;

namespace LearningManagementSystem.Application.Features_CQRS.Courses.Queries.GetAllCourse
{
    class GetAllCourseHandler : IRequestHandler<GetAllCourseQuery, List<DetailsCourseDto>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetAllCourseHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<DetailsCourseDto>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            //1️⃣ Fetch all courses with Instructor included
            var courses = await _courseRepository.GetAllAsync();

            if (courses == null || !courses.Any())
                return new List<DetailsCourseDto>();
           
            return courses.Adapt<List<DetailsCourseDto>>();
        }
    }
}
