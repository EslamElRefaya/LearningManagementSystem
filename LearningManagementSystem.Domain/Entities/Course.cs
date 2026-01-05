using System.ComponentModel.DataAnnotations;
using LearningManagementSystem.Domain.Common;
using LearningManagementSystem.Domain.DomainEvents;
using LearningManagementSystem.Domain.Enums;
using LearningManagementSystem.Domain.Events;
using LearningManagementSystem.Domain.ValueObjects;

namespace LearningManagementSystem.Domain.Entities
{
    public class Course : AuditableEntity
    {
        [MaxLength(250)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        public CourseStatus Status { get; set; } = CourseStatus.Draft;
        public Money CoursePrice { get; private set; } = null!;

        public Guid InstractorId { get; set; }
        public Instractor Instractor { get; set; }=default!;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
        
    }
}
