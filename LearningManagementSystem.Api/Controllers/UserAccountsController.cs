using LearningManagementSystem.Application.DTOs.Accounts;
using LearningManagementSystem.Application.Features_CQRS.Accounts.Commands.ForgotPassword;
using System.Security.Claims;
using LearningManagementSystem.Application.Features_CQRS.Accounts.Commands.Login;
using LearningManagementSystem.Application.Features_CQRS.Accounts.Commands.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LearningManagementSystem.Application.Features_CQRS.Accounts.Commands.ChangePassword;

namespace LearningManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {

        private readonly IMediator _mediator;
        public UserAccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserCommand createUserCommand)
        {
            var userDto = await _mediator.Send(createUserCommand);
            return Ok(userDto);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand loginUserCommand)
        {
            var token = await _mediator.Send(loginUserCommand);
            return Ok(new { token });
        }
     
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Email))
                return BadRequest(new { message = "Email is required." });

            var result = await _mediator.Send(new ForgotPasswordCommand(dto));
            return Ok(new { message = result }); // Show Token in Swagger
        }


        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Request body is required." });

            await _mediator.Send(new ResetPasswordCommand(dto));
            return Ok(new { message = "Password has been reset successfully." });
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.CurrentPassword) || string.IsNullOrEmpty(dto.NewPassword))
                return BadRequest(new { message = "CurrentPassword and NewPassword are required." });

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "Invalid token." });

            await _mediator.Send(new ChangePasswordCommand(userId, dto.CurrentPassword, dto.NewPassword));

            return Ok(new { message = "Password changed successfully." });
        }
    }
}
