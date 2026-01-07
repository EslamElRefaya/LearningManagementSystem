using LearningManagementSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Courses.Commands.UpdateCourse
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, Unit>
    {
        private readonly ICourseRepository _courseRepository;

        public UpdateCourseHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
           var course= await _courseRepository.GetByIdAsync(request.CourseId);
            if (course == null)
                throw new KeyNotFoundException($"Course with id {request.CourseId} not found");
            course.Title= request.Title;
            course.Description= request.Description;
            course.UpdatePrice(request.Price, request.Currency);
            course.InstractorId= request.InstractorId;
            await _courseRepository.UpdateAsync(course);
            return Unit.Value;
        }
    }
}
