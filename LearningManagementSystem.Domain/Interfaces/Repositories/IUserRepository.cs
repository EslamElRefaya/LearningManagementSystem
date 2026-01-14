using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Enums;

namespace LearningManagementSystem.Domain.Interfaces.Repositories
{
   public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> GetByRoleAsync(UserRole Role);
    }
}
