using MediatR;

public record AddOrUpdateUserRoleCommand(
    string UserName,
    string Role
) : IRequest<IEnumerable<string>>;
