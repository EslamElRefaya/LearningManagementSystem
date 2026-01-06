using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Enums;

namespace LearningManagementSystem.Domain.Interfaces.Repositories
{
   public interface ICourseRepository: IBaseRepository<Course>
    {
        Task PublishCourseAsync(Guid courseId);
        Task<Course?> GetCourseByTitleAsync(string title);
        Task<Course?> GetCourseByInstractorAsync(Guid instractorId);
        Task<List<Course>> GetCoursesByStatusAsync(CourseStatus status); 
    }
}
