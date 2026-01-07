public record UpdateCourseDto
(
    string Title,
    string Description,
    decimal Price,
    string Currency,
    Guid InstractorId
);
