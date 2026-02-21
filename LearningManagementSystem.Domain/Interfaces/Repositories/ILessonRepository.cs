using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Enums;

namespace LearningManagementSystem.Domain.Interfaces.Repositories
{
   public interface ILessonRepository:IBaseRepository<Lesson>
    {
        Task<IEnumerable<Lesson>> GetLessonByCourseIdAsync(Guid courseId);
        Task<IEnumerable<Lesson>> GetLessByLessonTypeAsync(LessonType LessonType);
    }
}
