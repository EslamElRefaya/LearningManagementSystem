using LearningManagementSystem.Application.DTOs.Users;
using MediatR;

namespace LearningManagementSystem.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<DetailsUserDto>>
    {
    }
}
