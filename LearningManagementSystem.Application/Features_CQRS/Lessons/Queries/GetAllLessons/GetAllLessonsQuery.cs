using LearningManagementSystem.Application.DTOs.Lessons;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Lessons.Queries.GetAllLessons
{
    public class GetAllLessonsQuery : IRequest<List<DetailsLessonDto>>
    { 
    }
}
