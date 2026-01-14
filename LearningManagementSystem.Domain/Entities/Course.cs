using System.ComponentModel.DataAnnotations;
using LearningManagementSystem.Domain.Common;
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

        private Course() { } // EF Core
      
        public static Course Create(string title, string description, decimal price, string currency, Guid instructorId)
        {
            return new Course
            {
                Title = title,
                Description = description,
                CoursePrice = new Money(price, currency),
                InstractorId = instructorId
            };
        }

        // Method to update price
        public void UpdatePrice(decimal price, string currency)
        {
            CoursePrice = new Money(price, currency);
        }

        // Domain Events list
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent eventItem) => _domainEvents.Add(eventItem);
        public void ClearDomainEvents() => _domainEvents.Clear();
        //away publish inter Aggregate
        public void Publish()
        {
            if (Status == CourseStatus.Published) return;

            Status = CourseStatus.Published;

            // бнк Domain Event
            //AddDomainEvent(new CoursePublishedEvent(Id, Title));
        }
    }
}
