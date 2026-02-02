using MediatR;
namespace LearningManagementSystem.Application.Features_CQRS.Accounts.Commands.Login
{
    public record LoginUserCommand(
     string UserName,
     string Password
 ) : IRequest<string>; // Return JWT Token
}
