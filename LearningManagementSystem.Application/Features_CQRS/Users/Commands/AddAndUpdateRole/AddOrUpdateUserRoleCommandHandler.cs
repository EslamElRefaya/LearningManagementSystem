using LearningManagementSystem.Application.Interfaces;
using MediatR;
public class AddOrUpdateUserRoleCommandHandler
    : IRequestHandler<AddOrUpdateUserRoleCommand, IEnumerable<string>>
{
    private readonly IUserRepository _userRepository;
    public AddOrUpdateUserRoleCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<string>> Handle(AddOrUpdateUserRoleCommand request,CancellationToken cancellationToken)
    {
        var role= await _userRepository.AddAndUpdateRolesAsync(request.UserName,request.Role);
        return role;
    }
}
