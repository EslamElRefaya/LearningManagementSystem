using LearningManagementSystem.Application.Features_CQRS.Courses.Commands.PublishCourse;
using LearningManagementSystem.Application.Features_CQRS.Courses.Queries.GetAllCourse;
using LearningManagementSystem.Application.Features_CQRS.Courses.Queries.GetCourseById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = "Student")]
        [HttpGet]
        public async Task<IActionResult> GetAllCoursesAsync()
        {
            var courses=await _mediator.Send(new GetAllCourseQuery());
            return Ok(courses);
        }
        [HttpGet("{courseid}")]
        public async Task<IActionResult> GetAllCoursesAsync(Guid courseid)
        {
            var courses = await _mediator.Send(new GetCourseByIdQuery(courseid));
            if (courses == null)
                return NotFound("this course not found");
            return Ok(courses);
        }
        // POST: api/Courses
        [HttpPost]
        public async Task<IActionResult> CreateCourseAsync([FromBody] CreateCourseDto createCourseDto)
        {
            var courseId = await _mediator.Send(createCourseDto);
            return Ok(courseId);
        }
        [HttpPut("{courseId}")]
        public async Task<IActionResult> UpdateCourseAsync(Guid courseId, [FromBody] UpdateCourseDto updateCourseDto)
        {
            var updateCourseCommand = new UpdateCourseCommand
            (
              courseId,
              updateCourseDto.Title,
              updateCourseDto.Description,
              updateCourseDto.Price,
              updateCourseDto.Currency,
              updateCourseDto.InstractorId
            );
            try
            {
                await _mediator.Send(updateCourseCommand);
                return Ok("Updated  by successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // 404
            }
        }

        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourseAsync(Guid courseId)
        {
            try
            {
                await _mediator.Send(new DeleteCourseCommand(courseId));
                return Ok("Delete Operation is successfully!");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }
        
        [HttpPatch("{courseId}/publish")]
        public async Task<IActionResult> PublishCourse(Guid courseId)
        {
            try
            {
                await _mediator.Send(new PublishCourseCommand(courseId));
                return Ok("Course published successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); 
            }
        }

    }
}