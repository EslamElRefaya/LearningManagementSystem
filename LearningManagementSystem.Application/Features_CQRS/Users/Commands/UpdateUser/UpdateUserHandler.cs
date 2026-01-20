using LearningManagementSystem.Application.Interfaces;
using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LearningManagementSystem.Application.Features_CQRS.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateUserCommandHandler(IUserRepository userRepository,
                                        UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // 1️ get Domain User
            var user = await _userRepository.GetDomainUserById(request.UserId);
            if (user == null)
                throw new Exception("User not found");

            // 2️ update  Domain User
            user.FullName = request.FullName;
            await _userRepository.UpdateUserAsync(user);

            // 3️ update  ApplicationUser
            var appUser = await _userManager.FindByIdAsync(user.Id.ToString());
            if (appUser != null)
            {
                appUser.UserName = request.UserName;
                appUser.Email = request.Email;
                appUser.PhoneNumber = request.PhoneNumber;

                var result = await _userManager.UpdateAsync(appUser);
                if (!result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            return user;
        }
    }
}

