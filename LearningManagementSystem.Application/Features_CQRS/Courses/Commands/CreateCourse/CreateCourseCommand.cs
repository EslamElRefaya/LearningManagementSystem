using MediatR;
public record CreateCourseCommand(
    string Title,
    string Description,
    decimal Price,
    string Currency,
    Guid InstractorId
):IRequest<Guid>;