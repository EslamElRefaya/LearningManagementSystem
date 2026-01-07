using LearningManagementSystem.Domain.Entities;

namespace LearningManagementSystem.Domain.Interfaces.Repositories
{
   public interface IInstractorRepository : IBaseRepository<Instractor>
    {
        Task<Instractor> GetInstractorByFullNameAsync(string name);
    }
}
