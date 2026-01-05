using LearningManagementSystem.Domain.Common;

namespace LearningManagementSystem.Domain.Entities
{
    public class Certificate: AuditableEntity
    {
        public String Title { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }= default!;

        public int UserId { get; set; }
        public User User { get; set; } = default!;

    }
}
