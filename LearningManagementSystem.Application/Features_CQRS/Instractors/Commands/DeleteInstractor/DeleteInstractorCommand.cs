using MediatR;
namespace LearningManagementSystem.Application.Features_CQRS.Instractors.Commands.DeleteInstractor
{
    public record DeleteInstractorCommand
    (
        Guid instractorId
    ):IRequest<Unit>;
}
