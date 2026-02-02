using LearningManagementSystem.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LearningManagementSystem.Application.Features_CQRS.Accounts.Commands.ChangePassword
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand,Unit>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ChangePasswordHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            //get on Identity
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            // Check on Current Password
            var isCorrect = await _userManager.CheckPasswordAsync(user, request.CurrentPassword);
            if (!isCorrect)
                throw new ArgumentException("Current password is incorrect");

            // Apply Change Password
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            return Unit.Value;
        }
    }
}
