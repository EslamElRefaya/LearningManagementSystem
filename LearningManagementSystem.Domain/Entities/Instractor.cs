using LearningManagementSystem.Domain.Common;

namespace LearningManagementSystem.Domain.Entities
{
  public class Instractor: AuditableEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Degree { get; set; } = string.Empty;
        public string Certificates { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
