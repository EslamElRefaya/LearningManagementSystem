using System.ComponentModel.DataAnnotations;
using LearningManagementSystem.Domain.Common;
namespace LearningManagementSystem.Domain.Entities
{
    public class User : AuditableEntity
    {
        [MaxLength(200)]
        public string FullName { get; set; } = string.Empty;
      

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Submission> Submissions { get; set; } = new List<Submission>();
       
    }
}
