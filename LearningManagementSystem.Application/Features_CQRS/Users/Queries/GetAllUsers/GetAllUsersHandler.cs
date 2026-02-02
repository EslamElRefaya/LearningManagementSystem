using LearningManagementSystem.Application.Contracts.Persistence;
using LearningManagementSystem.Application.DTOs.Users;
using LearningManagementSystem.Domain.Interfaces;
using MediatR;

namespace LearningManagementSystem.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

      
    }
}
