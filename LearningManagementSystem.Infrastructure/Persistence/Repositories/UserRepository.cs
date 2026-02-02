using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Interfaces;
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
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .Where(u => !u.IsDeleted)
            .ToListAsync();
    }
    public async Task<User?> GetUserById(Guid id)
    {
        return await _context.Users
           .AsNoTracking()
           .SingleOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
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

    public async Task UpdateUserAsync(Guid userId, string? fullName, string? email, string? userName, string? password, string? phone, string? role)
    {
        // 1️ Domain User
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == userId && !u.IsDeleted);

        if (user is null) throw new KeyNotFoundException("User not found");

        if (!string.IsNullOrEmpty(fullName)) user.FullName = fullName;

        _context.Users.Update(user);

        // 2️ Identity User
        var applicationUser = await _userManager.Users
            .FirstOrDefaultAsync(u => u.UserId == userId);

        if (applicationUser is null) throw new KeyNotFoundException("Identity user not found");

        if (!string.IsNullOrEmpty(userName)) applicationUser.UserName = userName;
        if (!string.IsNullOrEmpty(email)) applicationUser.Email = email;
        if (!string.IsNullOrEmpty(phone)) applicationUser.PhoneNumber = phone;

        var updateResult = await _userManager.UpdateAsync(applicationUser);
        if (!updateResult.Succeeded)
            throw new ArgumentException($"Failed to update identity user: {string.Join(", ", updateResult.Errors.Select(e => e.Description))}");

        // 3️ Password
        if (!string.IsNullOrEmpty(password))
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(applicationUser);
            var resetResult = await _userManager.ResetPasswordAsync(applicationUser, token, password);
            if (!resetResult.Succeeded)
                throw new InvalidOperationException($"Failed to reset password: {string.Join(", ", resetResult.Errors.Select(e => e.Description))}");
        }

        // 4️ Role
        if (!string.IsNullOrEmpty(role))
        {
            var currentRoles = await _userManager.GetRolesAsync(applicationUser);
            if (!currentRoles.Contains(role))
            {
                await _userManager.RemoveFromRolesAsync(applicationUser, currentRoles);
                await _userManager.AddToRoleAsync(applicationUser, role);
            }
        }
    }

    public async Task SoftDeleteUserAsync(User user)
    {
        user.SoftDelete();          //  Business Logic
        _context.Users.Update(user); // Update not Remove
        await Task.CompletedTask;
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

