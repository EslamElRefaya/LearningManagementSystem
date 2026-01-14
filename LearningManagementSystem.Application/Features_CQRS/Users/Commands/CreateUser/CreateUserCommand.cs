using LearningManagementSystem.Application.DTOs.Users;
using LearningManagementSystem.Domain.Enums;
using LearningManagementSystem.Domain.ValueObjects;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Users.Commands.CreateUser
{
    public record CreateUserCommand
     (
       string fullName,
       string email,
       string password,
       string userName,
       string phone,
       UserRole role
     ) : IRequest<DetailsUserDto>;
}
