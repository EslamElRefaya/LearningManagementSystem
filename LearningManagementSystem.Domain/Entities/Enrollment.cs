using LearningManagementSystem.Domain.Common;

namespace LearningManagementSystem.Domain.Entities
{
    public class Enrollment: AuditableEntity
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = default!;

        public Guid UserId { get; set; }
        public User User { get; set; }= default!;
        public bool IsCompleted { get; set; } = false;
    }
}
