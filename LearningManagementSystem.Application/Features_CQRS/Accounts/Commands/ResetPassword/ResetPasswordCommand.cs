using LearningManagementSystem.Application.DTOs.Accounts;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Accounts.Commands.ResetPassword
{
    public record ResetPasswordCommand(
            ResetPasswordDto resetPasswordDto
            ) : IRequest<Unit>;
}
