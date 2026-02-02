using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Accounts.Commands.ChangePassword
{
    public record ChangePasswordCommand(
    string UserId,
    string CurrentPassword,
    string NewPassword
) : IRequest<Unit>;
}
