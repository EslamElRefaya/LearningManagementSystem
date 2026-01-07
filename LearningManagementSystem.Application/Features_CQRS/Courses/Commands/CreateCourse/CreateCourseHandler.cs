using MediatR;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using LearningManagementSystem.Domain.Entities;
namespace LearningManagementSystem.Application.Features_CQRS.Courses.Commands.CreateCourse
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly ICourseRepository _courseRepository;

        public CreateCourseHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = Course.Create(
                request.Title,
                request.Description,
                request.Price,
                request.Currency,
                request.InstractorId
                );


            await _courseRepository.AddAsync(course);
            return course.Id;
        }
    }
}
