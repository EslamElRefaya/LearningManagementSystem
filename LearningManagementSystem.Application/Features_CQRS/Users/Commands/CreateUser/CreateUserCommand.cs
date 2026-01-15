using LearningManagementSystem.Application.DTOs.Users;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Users.Commands.CreateUser
{
    public record CreateUserCommand
        (
        CreateUpdateUserDto createUserDto
        ) : IRequest<DetailsUserDto>;
}
