using LearningManagementSystem.Domain.Common;

namespace LearningManagementSystem.Domain.Entities
{
    public class Enrollment: AuditableEntity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;

        public int StudentId { get; set; }
        public User Student { get; set; }= default!;
        public bool IsCompleted { get; set; } = false;
    }
}
