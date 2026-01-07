using LearningManagementSystem.Application.DTOs.Instractors;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Instractors.Commands.UpdateInstractor
{
   public record UpdateInstractorCommand
     (
        Guid instractorId,
        CreateAndUpdateInstractorDto createAndUpdateInstractorDto
     ):IRequest<Unit>;
}
