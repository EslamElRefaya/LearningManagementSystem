using MediatR;
public record CreateCourseHandler(string title, string description):IRequest<Guid>;
    

