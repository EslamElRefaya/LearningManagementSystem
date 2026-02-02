using LearningManagementSystem.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using NETCore.MailKit.Core;

namespace LearningManagementSystem.Application.Features_CQRS.Accounts.Commands.ForgotPassword
{
    public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordCommand, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _env;

        public ForgotPasswordHandler(UserManager<ApplicationUser> userManager,
                                     IEmailService emailService,
                                     IWebHostEnvironment env)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _env = env ?? throw new ArgumentNullException(nameof(env));
        }

        public async Task<string> Handle(ForgotPasswordCommand request, CancellationToken _)
        {
            var email = request.forgotPasswordDto?.Email?.Trim();
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email is required.");

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                // ·« ‰ﬂ‘› ÊÃÊœ «·≈Ì„Ì· ·√„«‰
                return "If the email exists, a reset link has been sent.";
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = $"https://yourapp.com/reset-password?email={email}&token={Uri.EscapeDataString(token)}";

            if (_env.IsDevelopment())
            {
                // Dev Mode: return the link directly in Swagger response
                return resetLink;
            }
            else
            {
                // Prod Mode: send email
                await _emailService.SendAsync(email, "Reset Password", $"Click here: {resetLink}");
                return "If the email exists, a reset link has been sent.";
            }
        }
    }
}
