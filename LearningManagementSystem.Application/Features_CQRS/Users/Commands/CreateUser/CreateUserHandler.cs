using LearningManagementSystem.Application.Interfaces;
using LearningManagementSystem.Domain.Entities;
using MediatR;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly IUserRepository _userRepository;
    public CreateUserHandler(IUserRepository service) => _userRepository = service;

    public async Task<User> Handle(CreateUserCommand r, CancellationToken _)
        => await _userRepository.CreateUserAsync(r.FullName, r.Email, r.UserName, r.Password, r.Phone);
}
