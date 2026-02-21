using System.ComponentModel.DataAnnotations;
using LearningManagementSystem.Domain.Enums;

namespace LearningManagementSystem.Application.DTOs.Lessons
{
  public class CreateLessonDto
    {
        [MaxLength(250)]
        public string Title { get; set; } = string.Empty;
        public LessonType LessonType { get; set; }
        public int Order { get; set; }
        public Guid CourseId { get; set; }
    }
}
