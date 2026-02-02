using Azure.Core;
using LearningManagementSystem.Application.DTOs.Instractors;
using LearningManagementSystem.Application.Features_CQRS.Instractors.Commands.CreateInstractor;
using LearningManagementSystem.Application.Features_CQRS.Instractors.Commands.DeleteInstractor;
using LearningManagementSystem.Application.Features_CQRS.Instractors.Commands.UpdateInstractor;
using LearningManagementSystem.Application.Features_CQRS.Instractors.Queries.GetAllInstractor;
using LearningManagementSystem.Application.Features_CQRS.Instractors.Queries.GetInstractorById;
using LearningManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Api.Controllers
{
   // [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> GetAllAsync()
        {
           var instractors= await _mediator.Send(new GetAllInstractorQuery());
            if (instractors == null)
                return Ok("No data added yet!");
            return Ok(instractors);
        }
        [HttpGet("{instractorId}")]
        public async Task<IActionResult> GetByIdAsync(Guid instractorId)
        {
               var instractor = await _mediator.Send(new GetInstractorByIdQuery(instractorId));
            if (instractor == null)
                throw new KeyNotFoundException("instractor is not found");

            return Ok(instractor);
           
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateAndUpdateInstractorDto createAndUpdateInstractorDto)
        {
            if (createAndUpdateInstractorDto == null)
                throw new ArgumentException("instractor is  requierd");
            var id = await _mediator.Send(new CreateInstractorCommand(createAndUpdateInstractorDto));
            return Ok(id);
        }
        [HttpPut("{instractorId}")]
        public async Task<IActionResult> UpdateAsync(Guid instractorId, [FromBody] CreateAndUpdateInstractorDto createAndUpdateInstractorDto)
        {
             var command = new UpdateInstractorCommand(instractorId, createAndUpdateInstractorDto);
                await _mediator.Send(command);
                return Ok("The Update is Successs"); 
        }

        [HttpDelete("{instractorId}")]
        public async Task<IActionResult> DeleteAsync(Guid instractorId)
        {
                await _mediator.Send(new DeleteInstractorCommand(instractorId));
                return Ok("Delete is Success!");   
        }

    }
}
