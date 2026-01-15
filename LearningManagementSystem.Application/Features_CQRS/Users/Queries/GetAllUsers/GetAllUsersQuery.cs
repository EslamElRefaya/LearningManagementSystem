using LearningManagementSystem.Application.DTOs.Users;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<DetailsUserDto>>
    {
    }
}
