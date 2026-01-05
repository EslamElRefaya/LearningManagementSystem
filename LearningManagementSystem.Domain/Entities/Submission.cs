using System.ComponentModel.DataAnnotations;
using LearningManagementSystem.Domain.Common;

namespace LearningManagementSystem.Domain.Entities
{
   public class Submission: AuditableEntity
    {
        [MaxLength(300)]
        public string FileUrl { get; set; } = string.Empty;
        public float? Grade { get; set; }

        public Guid AssignmentId { get; set; }
        public Assignment Assignment { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
