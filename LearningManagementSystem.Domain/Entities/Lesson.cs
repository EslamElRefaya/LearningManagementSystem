using LearningManagementSystem.Domain.Common;
using LearningManagementSystem.Domain.Enums;

namespace LearningManagementSystem.Domain.Entities
{
   public class Lesson: AuditableEntity
    {
        public string Title { get; set; }=string.Empty;
        public LeassonType LeassonType { get; set; }
        public int Order { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;


    }
}
