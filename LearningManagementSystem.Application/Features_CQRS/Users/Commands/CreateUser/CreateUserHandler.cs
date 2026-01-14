using LearningManagementSystem.Application.DTOs.Users;
using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Enums;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using LearningManagementSystem.Domain.ValueObjects;
using Mapster;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, DetailsUserDto>
    {
        private readonly IUserRepository _userRepository;
        
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<DetailsUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //create objects value for email
            var email = new Email(request.email);
            var user = new User
                (
                    request.fullName,
                    email,
                    request.password,
                    request.userName,
                    request.phone,
                    request.role
                );
           await _userRepository.AddAsync(user);

            var userdto= user.Adapt<DetailsUserDto>();
            return userdto;

        }
    }
}
