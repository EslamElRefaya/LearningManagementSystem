using LearningManagementSystem.Domain.Interfaces;
using MediatR;
namespace LearningManagementSystem.Application.Features_CQRS.Users.Commands.AddAndUpdateRole
{
    public class AddOrUpdateUserRoleHandler
    : IRequestHandler<AddOrUpdateUserRoleCommand, IEnumerable<string>>
    {
        private readonly IUserRepository _userRepository;
        public AddOrUpdateUserRoleHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<string>> Handle(AddOrUpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _userRepository.AddAndUpdateRolesAsync(request.UserName, request.Role);
            return role;
        }
    }
}
