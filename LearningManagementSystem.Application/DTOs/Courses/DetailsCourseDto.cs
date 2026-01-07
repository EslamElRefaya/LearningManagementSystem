
public record class DetailsCourseDto

(
    Guid CourseId,
    string Title,
    string Description,
    decimal Price,
    string StatusPublishing,
    string Currency,
    string InstractorName
);
