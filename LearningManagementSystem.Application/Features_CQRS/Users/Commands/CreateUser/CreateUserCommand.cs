using LearningManagementSystem.Domain.Entities;
using MediatR;

public record CreateUserCommand
    (
    string FullName,
    string Email,
    string UserName,
    string Password,
    string Phone
) : IRequest<User>;