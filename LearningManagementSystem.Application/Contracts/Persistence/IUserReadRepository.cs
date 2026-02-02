using LearningManagementSystem.Application.DTOs.Users;

namespace LearningManagementSystem.Application.Contracts.Persistence
{
    public interface IUserReadRepository
    {
        Task<List<DetailsUserDto>> GetAllUsersAsync();
    }
}
