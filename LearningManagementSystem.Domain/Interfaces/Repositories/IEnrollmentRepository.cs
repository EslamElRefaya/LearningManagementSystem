using LearningManagementSystem.Domain.Entities;

namespace LearningManagementSystem.Domain.Interfaces.Repositories
{
   public interface IEnrollmentRepository : IBaseRepository<Enrollment>
    {
        Task  GetCountEnrollmentsInCourseAsync();
    }
}
