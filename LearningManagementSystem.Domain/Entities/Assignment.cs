using LearningManagementSystem.Domain.Common;

namespace LearningManagementSystem.Domain.Entities
{
    public class Assignment : AuditableEntity
    {
        public string Title { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }

       public ICollection<Submission> Submissions { get; set; } = new List<Submission>();
    }
}
