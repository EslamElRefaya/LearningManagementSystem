using LearningManagementSystem.Application.DTOs.Users;
using LearningManagementSystem.Application.Features_CQRS.Users.Commands.DeleteUser;
using LearningManagementSystem.Application.Features_CQRS.Users.Commands.Login;
using LearningManagementSystem.Application.Features_CQRS.Users.Commands.UpdateUser;
using LearningManagementSystem.Application.Features_CQRS.Users.Queries.GetAllUsers;
using LearningManagementSystem.Application.Features_CQRS.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserCommand createUserCommand)
        {
            var user = await _mediator.Send(createUserCommand);
            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(new { token });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateUserCommand command)
        {
            if (id != command.UserId)
                return BadRequest("Id mismatch");

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok("delete is successed");
        }
        [HttpPut("role")]
        public async Task<IActionResult> AddOrUpdateRole(AddOrUpdateUserRoleCommand command)
        {
            var roles = await _mediator.Send(command);
            return Ok(roles);
        }
    }
}
