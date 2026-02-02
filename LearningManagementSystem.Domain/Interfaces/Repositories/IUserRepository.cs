using LearningManagementSystem.Domain.Entities;
namespace LearningManagementSystem.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> CreateUserAsync(string fullName, string email, string userName, string password, string phone);
        Task<User?> GetUserById(Guid id);
        Task UpdateUserAsync(Guid userId, string? fullName, string? email, string? userName, string? password, string? phone, string? role);

        Task SoftDeleteUserAsync(User user);
        Task<IEnumerable<string>> AddAndUpdateRolesAsync(string userName, string role);
        Task<bool> CheckPasswordAsync(string userName, string password);

    }
}
