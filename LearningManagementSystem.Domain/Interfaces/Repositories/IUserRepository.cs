using LearningManagementSystem.Domain.Entities;

namespace LearningManagementSystem.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(string fullName, string email, string userName, string password, string phone);
        Task<User?> GetDomainUserById(Guid id);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);

        Task<IEnumerable<string>> AddAndUpdateRolesAsync(string userName, string role);
        Task<bool> CheckPasswordAsync(string userName, string password);

    }
}
