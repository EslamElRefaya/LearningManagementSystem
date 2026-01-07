using MediatR;
public record DeleteCourseCommand( Guid courseId) :IRequest<Unit>;