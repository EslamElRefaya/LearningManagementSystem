using LearningManagementSystem.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LearningManagementSystem.Application.Features_CQRS.Accounts.Commands.ResetPassword
{
    public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, Unit>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResetPasswordHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken _)
        {
            var dto = request.resetPasswordDto;

            if (string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.Token) ||
                string.IsNullOrWhiteSpace(dto.NewPassword))
            {
                throw new ArgumentException("Email, Token and NewPassword are required.");
            }

            var user = await _userManager.FindByEmailAsync(dto.Email.Trim());
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            var decodedToken = Uri.UnescapeDataString(dto.Token);

            var result = await _userManager.ResetPasswordAsync(user, decodedToken, dto.NewPassword);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Password reset failed: {errors}");
            }

            return Unit.Value;
        }
    }
}
