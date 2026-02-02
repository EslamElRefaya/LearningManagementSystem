using LearningManagementSystem.Application.DTOs.Accounts;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Accounts.Commands.Register
{
    public record RegisterUserCommand
        (
        string FullName,
        string Email,
        string UserName,
        string Password,
        string Phone
    ) : IRequest<DetailsRegistrationDto>;
}