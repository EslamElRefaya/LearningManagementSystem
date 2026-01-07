using MediatR;
using LearningManagementSystem.Application.Features_CQRS.Courses.Notifications;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using LearningManagementSystem.Domain.Events;

namespace LearningManagementSystem.Application.Features_CQRS.Courses.Commands.PublishCourse
{
    public class PublishCourseHandler : IRequestHandler<PublishCourseCommand, Unit>
    {
        private readonly ICourseRepository _repository;
        private readonly IMediator _mediator;

        public PublishCourseHandler(ICourseRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(PublishCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _repository.GetByIdAsync(request.CourseId);
            if (course == null)
                throw new KeyNotFoundException($"Course with Id {request.CourseId} not found.");

            // publish course in Aggregate
            course.Publish();

            
            await _repository.UpdateAsync(course);

            // Swnd Domain Events as Notifications
            foreach (var domainEvent in course.DomainEvents)
            {
                if (domainEvent is CoursePublishedEvent ev)
                {
                    await _mediator.Publish(new CoursePublishedNotification(ev.CourseId, ev.Title), cancellationToken);
                }
            }

            // remove DomainEvents after sending
            course.ClearDomainEvents();

            return Unit.Value;
        }
    }
}
