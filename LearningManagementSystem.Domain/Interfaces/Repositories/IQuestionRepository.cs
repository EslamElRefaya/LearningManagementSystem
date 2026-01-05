using LearningManagementSystem.Domain.Entities;

namespace LearningManagementSystem.Domain.Interfaces.Repositories
{
   public interface IQuestionRepository:IBaseRepository<Question>
    {
        Task<IEnumerable<Question>> GetQuestionsByQuizIdAsync(Guid quizId);
        Task GetQuestionsTitleQuestionByAsync(string titleQuestion);
    }
}
