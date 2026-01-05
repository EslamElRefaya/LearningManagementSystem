using LearningManagementSystem.Domain.Entities;

namespace LearningManagementSystem.Domain.Interfaces.Repositories
{
   public interface IInstractorRepository : IBaseRepository<Certificate>
    {
        Task<Instractor> GetInstractorByFullNameAsync(string name);
    }
}
