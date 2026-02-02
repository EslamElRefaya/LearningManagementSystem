using LearningManagementSystem.Application.DTOs.Accounts;
using LearningManagementSystem.Domain.Interfaces;
using Mapster;
using MediatR;
namespace LearningManagementSystem.Application.Features_CQRS.Accounts.Commands.Register
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, DetailsRegistrationDto>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserHandler(IUserRepository service) => _userRepository = service;

        public async Task<DetailsRegistrationDto> Handle(RegisterUserCommand request, CancellationToken _)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ArgumentException("Email is required");
            var user = await _userRepository.CreateUserAsync(request.FullName, request.Email, request.UserName, request.Password, request.Phone);
            return user.Adapt<DetailsRegistrationDto>();
        }

    }
}
