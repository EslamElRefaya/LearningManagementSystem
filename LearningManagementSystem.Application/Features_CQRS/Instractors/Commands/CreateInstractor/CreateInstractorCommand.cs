using LearningManagementSystem.Application.DTOs.Instractors;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Instractors.Commands.CreateInstractor
{
    public record CreateInstractorCommand
     (
        CreateAndUpdateInstractorDto createAndUpdateInstractorDto
     ) : IRequest<Guid>;
}
