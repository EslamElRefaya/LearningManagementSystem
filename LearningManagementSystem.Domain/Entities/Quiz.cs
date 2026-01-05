using LearningManagementSystem.Domain.Common;
using LearningManagementSystem.Domain.Enums;

namespace LearningManagementSystem.Domain.Entities
{
   public class Quiz: AuditableEntity
    {
        public string Title { get; set; } = string.Empty;
        public QuizType QuizType { get; set; } 
        public float MiniPassing { get; set; } 

        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
