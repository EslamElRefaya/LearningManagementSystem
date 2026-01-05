using System.ComponentModel.DataAnnotations;
using LearningManagementSystem.Domain.Common;

namespace LearningManagementSystem.Domain.Entities
{
    public class Question: AuditableEntity
    {
        [MaxLength(500)]
        public string QuestionContent { get; set; } = string.Empty;
        [MaxLength(500)]
        public string QuestionAnswer { get; set; } = string.Empty;

        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; } = default!;

    }
}
