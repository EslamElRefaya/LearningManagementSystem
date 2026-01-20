using LearningManagementSystem.Application.DTOs.Users;
using MediatR;
namespace LearningManagementSystem.Application.Features_CQRS.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(Guid UserId) : IRequest<Unit>;

}
