using System.ComponentModel.DataAnnotations;
using LearningManagementSystem.Domain.Common;

namespace LearningManagementSystem.Domain.Entities
{
    public class Assignment : AuditableEntity
    {
        [MaxLength(250)]
        public string Title { get; set; }=string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }

       public ICollection<Submission> Submissions { get; set; } = new List<Submission>();
    }
}
