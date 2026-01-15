using LearningManagementSystem.Application.DTOs.Users;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Users.Commands.UpdateUser
{
    public record UpdateUserCommand
    (
         Guid userId,
         CreateUpdateUserDto updateUserDto
    ) : IRequest<DetailsUserDto>;
}
