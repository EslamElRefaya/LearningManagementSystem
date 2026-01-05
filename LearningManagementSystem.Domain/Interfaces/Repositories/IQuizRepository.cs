using LearningManagementSystem.Domain.Entities;

namespace LearningManagementSystem.Domain.Interfaces.Repositories
{
   public interface IQuizRepository:IBaseRepository<Quiz>
    {
        Task<Quiz> GetQuizByCourseIdAsync(Guid courseId);
    }
}
