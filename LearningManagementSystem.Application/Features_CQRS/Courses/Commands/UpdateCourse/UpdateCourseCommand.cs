using MediatR;
public record UpdateCourseCommand
    (
    Guid CourseId,
    string Title,
    string Description,
    decimal Price,
    string Currency,
    Guid InstractorId
    ) :IRequest<Unit>;