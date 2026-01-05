using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Enums;

namespace LearningManagementSystem.Domain.Interfaces.Repositories
{
   public interface ILessonRepository:IBaseRepository<Lesson>
    {
        Task<Lesson?> GetLessonByCourseIdAsync(Guid courseId);
        Task<IEnumerable<Lesson>> GetLessonsLeassonTypeAsync(LeassonType leassonType);
    }
}
