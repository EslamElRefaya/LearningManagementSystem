using LearningManagementSystem.Domain.Common;

namespace LearningManagementSystem.Domain.Entities
{
   public class Submission: AuditableEntity
    {
        public string FileUrl { get; set; } = string.Empty;
        public float? Grade { get; set; }

        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
