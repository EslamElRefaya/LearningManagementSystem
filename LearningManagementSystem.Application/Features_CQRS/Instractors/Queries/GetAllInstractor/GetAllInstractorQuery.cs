using LearningManagementSystem.Application.DTOs.Instractors;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Instractors.Queries.GetAllInstractor
{
    public class GetAllInstractorQuery:IRequest<List<DetailsInstractorDto>>
    {
    }
}
