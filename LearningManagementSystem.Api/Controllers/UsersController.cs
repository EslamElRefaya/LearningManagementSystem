using LearningManagementSystem.Application.DTOs.Users;
using LearningManagementSystem.Application.Features_CQRS.Users.Commands.CreateUser;
using LearningManagementSystem.Application.Features_CQRS.Users.Commands.DeleteUser;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailsUserDto>>> GetAll()
        => Ok(await _mediator.Send(new GetAllUsersQuery()));

        [HttpGet("{id}")]
        public async Task<ActionResult<DetailsUserDto>> GetById(Guid id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { UserId = id });

            if (user == null)
                return NotFound("User not found" );

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<DetailsUserDto>> Create([FromBody] CreateUpdateUserDto createUserDto)
        {
            var userDto = await _mediator.Send(new CreateUserCommand(createUserDto));
            return Ok(userDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateUpdateUserDto updateUserDto)
        {
            var userdto= await _mediator.Send(new UpdateUserCommand ( userId: id, updateUserDto: updateUserDto));
            return Ok(userdto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
          var userdto=  await _mediator.Send(new DeleteUserCommand (UserId: id));
            return Ok(userdto);
        }
    }
}
