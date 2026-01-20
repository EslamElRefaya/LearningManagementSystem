using LearningManagementSystem.Domain.Entities;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(
      Guid UserId,        // Id from Tb User
      string FullName,
      string UserName,
      string Email,
      string PhoneNumber
  ) : IRequest<User>;
}
