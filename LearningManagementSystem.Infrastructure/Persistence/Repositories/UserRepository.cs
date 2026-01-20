using LearningManagementSystem.Application.Interfaces;
using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Infrastructure.Identity;
using LearningManagementSystem.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public UserRepository(UserManager<ApplicationUser> userManager,
                           ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    // Registration
    public async Task<User> CreateUserAsync(string fullName, string email, string userName, string password, string phone)
    {
        var domainUser = new User { FullName = fullName };
        _context.Users.Add(domainUser);
        await _context.SaveChangesAsync();

        var appUser = new ApplicationUser
        {
            UserId = domainUser.Id,
            User = domainUser,
            Email = email,
            UserName = userName,
            PhoneNumber = phone
        };

        var result = await _userManager.CreateAsync(appUser, password);
        if (!result.Succeeded)
            throw new Exception(string.Join(",", result.Errors.Select(e => e.Description)));

        await _userManager.AddToRoleAsync(appUser, "Student");

        return domainUser;
    }
    public async Task<User?> GetDomainUserById(Guid id)
    {
        return await _context.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteUserAsync(Guid id)
    {
        var user = await GetDomainUserById(id);
        if (user == null)
            return;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    //update on roles
    public async Task<IEnumerable<string>> AddAndUpdateRolesAsync(string userName, string role)
    {
        // 1️ Get user
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            throw new Exception("User not found");

        // 2️ Get current roles
        var currentRoles = await _userManager.GetRolesAsync(user);

        // 3️ Remove existing roles (Update)
        if (currentRoles.Any())
        {
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResult.Succeeded)
                throw new Exception(string.Join(", ",
                    removeResult.Errors.Select(e => e.Description)));
        }

        // 4️ Add new role
        if (!await _userManager.IsInRoleAsync(user, role))
        {
            var addResult = await _userManager.AddToRoleAsync(user, role);
            if (!addResult.Succeeded)
                throw new Exception(string.Join(", ",
                    addResult.Errors.Select(e => e.Description)));
        }

        // 5️ Return updated roles as IEnumerable<string>
        return await _userManager.GetRolesAsync(user);
    }

    /// Check user password
    public async Task<bool> CheckPasswordAsync(string userName, string password)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null) return false;
        return await _userManager.CheckPasswordAsync(user, password);
    }


}

