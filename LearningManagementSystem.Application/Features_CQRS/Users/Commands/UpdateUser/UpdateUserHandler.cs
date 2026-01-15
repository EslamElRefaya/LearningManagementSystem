using LearningManagementSystem.Application.DTOs.Users;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using LearningManagementSystem.Domain.ValueObjects;
using Mapster;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, DetailsUserDto>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DetailsUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.userId);
            if (user == null) throw new Exception("User not found");

            // update Email separately because Email is Value Object
            user.UpdateEmail(new Email(request.updateUserDto.Email));

            // update all items by using  Mapster
            request.updateUserDto.Adapt(user);

            await _userRepository.UpdateAsync(user);

            return user.Adapt<DetailsUserDto>();
        }
    }
}
