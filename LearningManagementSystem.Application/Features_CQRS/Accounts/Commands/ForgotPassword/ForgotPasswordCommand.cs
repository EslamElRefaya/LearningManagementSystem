using LearningManagementSystem.Application.DTOs.Accounts;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Accounts.Commands.ForgotPassword
{
    public record ForgotPasswordCommand(ForgotPasswordDto forgotPasswordDto ) : IRequest<string>;
}
