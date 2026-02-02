using LearningManagementSystem.Application.DTOs.Users;
using LearningManagementSystem.Application.Features.Users.Queries.GetAllUsers;
using LearningManagementSystem.Application.Features_CQRS.Users.Commands.DeleteUser;
using LearningManagementSystem.Application.Features_CQRS.Users.Commands.UpdateUser;
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
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserCommand createUserCommand)
        {
            var userId= await _mediator.Send(createUserCommand);
            return Ok(userId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] CreateUpdateUserDto dto)
        {
            await _mediator.Send(new UpdateUserCommand(id, dto));
            return Ok("Update is successed");
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
