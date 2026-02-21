using LearningManagementSystem.Application.DTOs.Lessons;
using LearningManagementSystem.Application.Features_CQRS.Lessons.Commands.CreateLesson;
using LearningManagementSystem.Application.Features_CQRS.Lessons.Commands.DeleteLesson;
using LearningManagementSystem.Application.Features_CQRS.Lessons.Commands.UpdateLesson;
using LearningManagementSystem.Application.Features_CQRS.Lessons.Queries.GetAllLessons;
using LearningManagementSystem.Application.Features_CQRS.Lessons.Queries.GetLessonByCourseId;
using LearningManagementSystem.Application.Features_CQRS.Lessons.Queries.GetLessonById;
using LearningManagementSystem.Application.Features_CQRS.Lessons.Queries.GetLessonByLessonType;
using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LessonsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLessons()
        {
            var lessons = await _mediator.Send(new GetAllLessonsQuery());
            return Ok(lessons);
        }
        [HttpGet("{lessonId}")]
        public async Task<IActionResult> GetLessonById(Guid lessonId)
        {
            var lesson = await _mediator.Send(new GetLessonByIdQuery(lessonId));
            return Ok(lesson);
        }
        [HttpGet("GetLessonByCourseId/{courseId}")]
        public async Task<IActionResult> GetLessonByCourseId(Guid courseId)
        {
            var lesson = await _mediator.Send(new GetLessonByCourseIdQuery(courseId));
            return Ok(lesson);
        }
        [HttpGet("by-type")]
        public async Task<IActionResult> GetByType([FromQuery] LessonType type)
        {
            var lesson = await _mediator.Send(new GetLessonByLessonTypeQuery(type));
            return Ok(lesson);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLesson(CreateLessonCommand createLessonCommand)
        {
            await _mediator.Send(createLessonCommand);
            return Ok("Leasson is been Added");
        }
        [HttpPut("{lessonId}")]
        public async Task<IActionResult> UpdateLesson(Guid lessonId,[FromBody] UpdateLessonDto updateLessonDto)
        {
            await _mediator.Send(new UpdateLessonCommand(lessonId, updateLessonDto));
            return Ok("Leasson is been Update");
        }
        [HttpDelete("{lessonId}")]
        public async Task<IActionResult> DeleteLesson(Guid lessonId)
        {
            await _mediator.Send(new DeleteLessonCommand(lessonId));
            return Ok("Leasson is been Deleted");
        }
    }
}
