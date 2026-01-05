using LearningManagementSystem.Domain.Entities;

namespace LearningManagementSystem.Domain.Interfaces.Repositories
{
    interface ICertificateRepository : IBaseRepository<Certificate>
    {
        Task<List<Certificate>> GetCertificatesByCourseIdAsync(Guid courseId);
    }
}
