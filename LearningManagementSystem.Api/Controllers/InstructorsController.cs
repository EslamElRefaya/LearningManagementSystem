using LearningManagementSystem.Application.DTOs.Instractors;
using LearningManagementSystem.Application.Features_CQRS.Instractors.Commands.CreateInstractor;
using LearningManagementSystem.Application.Features_CQRS.Instractors.Commands.DeleteInstractor;
using LearningManagementSystem.Application.Features_CQRS.Instractors.Commands.UpdateInstractor;
using LearningManagementSystem.Application.Features_CQRS.Instractors.Queries.GetAllInstractor;
using LearningManagementSystem.Application.Features_CQRS.Instractors.Queries.GetInstractorById;
using LearningManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstructorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInstractorsAsync()
        {
           var instractors= await _mediator.Send(new GetAllInstractorQuery());
            if (instractors == null)
                return Ok("No data added yet!");
            return Ok(instractors);
        }
        [HttpGet("{instractorId}")]
        public async Task<IActionResult> GetInstractorByInstractorIdAsync(Guid instractorId)
        {
            try
            {
                var instractor = await _mediator.Send(new GetInstractorByIdQuery(instractorId));
                return Ok(instractor);
            }catch (Exception ex)
            {
                return NotFound("no data founded");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddInstractorAsync([FromBody] CreateAndUpdateInstractorDto createAndUpdateInstractorDto)
        {
            var id = await _mediator.Send(new CreateInstractorCommand(createAndUpdateInstractorDto));
            return Ok(id);
        }
        [HttpPut("{instractorId}")]
        public async Task<IActionResult> UpdateInstractorAsync(Guid instractorId, [FromBody] CreateAndUpdateInstractorDto createAndUpdateInstractorDto)
        {

            if (createAndUpdateInstractorDto == null)
                return BadRequest("Instractor is Requierd!");
            try
            {
                var command = new UpdateInstractorCommand(instractorId, createAndUpdateInstractorDto);
                await _mediator.Send(command);
                return Ok("The Update is Successs");

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{instractorId}")]
        public async Task<IActionResult> DeleteInstractorAsync(Guid instractorId)
        {
            try
            {
                await _mediator.Send(new DeleteInstractorCommand(instractorId));
                return Ok("Delete is Success!");
            }catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
           
        }

    }
}
