using LearningManagementSystem.Application.DTOs.Users;
using MediatR;
namespace LearningManagementSystem.Application.Features_CQRS.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<DetailsUserDto>
    {
        public Guid UserId { get; init; }
    }
}
