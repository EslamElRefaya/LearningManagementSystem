using LearningManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Application.DTOs.Lessons
{
    public class UpdateLessonDto
    {
        [MaxLength(250)]
        public string Title { get; set; } = string.Empty;
        public LessonType LessonType { get; set; }
        public int Order { get; set; }
        public Guid CourseId { get; set; }
    }
}
