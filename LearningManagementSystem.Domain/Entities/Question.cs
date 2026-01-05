using LearningManagementSystem.Domain.Common;

namespace LearningManagementSystem.Domain.Entities
{
    public class Question: AuditableEntity
    {
        public string QuestionContent { get; set; } = string.Empty;
        public string QuestionAnswer { get; set; } = string.Empty;

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = default!;

    }
}
