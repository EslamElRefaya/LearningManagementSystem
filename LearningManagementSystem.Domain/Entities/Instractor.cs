using System.ComponentModel.DataAnnotations;
using LearningManagementSystem.Domain.Common;

namespace LearningManagementSystem.Domain.Entities
{
  public class Instractor: AuditableEntity
    {
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;
        [MaxLength(300)]
        public string Degree { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Certificates { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Bio { get; set; } = string.Empty;

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
