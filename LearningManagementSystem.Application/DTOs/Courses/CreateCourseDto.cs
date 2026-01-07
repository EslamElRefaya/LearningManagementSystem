public record CreateCourseDto
    (
    string Title,
    string Description,
    decimal Price,
    string Currency,
    Guid InstractorId
);