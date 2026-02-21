namespace LearningManagementSystem.Application.DTOs.Lessons
{
   public class DetailsLessonDto
    {
        public Guid LessonId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string LessonType { get; set; } = string.Empty;
        public int Order { get; set; }
        public string CourseName { get; set; } = string.Empty;

    }
}
