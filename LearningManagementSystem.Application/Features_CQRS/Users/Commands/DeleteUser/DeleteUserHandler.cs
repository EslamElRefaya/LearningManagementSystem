using LearningManagementSystem.Application.DTOs.Users;
using LearningManagementSystem.Application.Interfaces;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using LearningManagementSystem.Infrastructure.Identity;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Application.Features_CQRS.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand,Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteUserCommandHandler(IUserRepository userRepository,UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetDomainUserById(request.UserId)
                       ?? throw new Exception("User not found");

            // 1️⃣ Delete Identity User
            var appUser = await _userManager.Users
                .FirstOrDefaultAsync(x => x.UserId == user.Id);

            if (appUser != null)
            {
                var result = await _userManager.DeleteAsync(appUser);
                if (!result.Succeeded)
                    throw new Exception(string.Join(", ",
                        result.Errors.Select(e => e.Description)));
            }

            // 2️⃣ Delete Domain User
            await _userRepository.DeleteUserAsync(user.Id);

            return Unit.Value;
        }

    }
}
