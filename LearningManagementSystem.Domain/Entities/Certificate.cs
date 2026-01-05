using System.ComponentModel.DataAnnotations;
using LearningManagementSystem.Domain.Common;

namespace LearningManagementSystem.Domain.Entities
{
    public class Certificate: AuditableEntity
    {
        [MaxLength(300)]
        public String Title { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }= default!;

        public Guid UserId { get; set; }
        public User User { get; set; } = default!;

    }
}
