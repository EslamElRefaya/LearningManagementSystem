using System.ComponentModel.DataAnnotations;
using LearningManagementSystem.Domain.Common;
using LearningManagementSystem.Domain.Enums;

namespace LearningManagementSystem.Domain.Entities
{
   public class Lesson: AuditableEntity
    {
        [MaxLength(250)]
        public string Title { get; set; }=string.Empty;
        public LeassonType LeassonType { get; set; }
        public int Order { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; } = default!;


    }
}
