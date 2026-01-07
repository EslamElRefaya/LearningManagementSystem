using LearningManagementSystem.Application.DTOs.Instractors;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Instractors.Queries.GetInstractorById
{
    public class GetInstractorByIdQuery : IRequest<DetailsInstractorDto>
    {
        public Guid InstractorId { get; set; }
        public GetInstractorByIdQuery(Guid instractorId)
        {
            InstractorId = instractorId;
        }
    }
}
