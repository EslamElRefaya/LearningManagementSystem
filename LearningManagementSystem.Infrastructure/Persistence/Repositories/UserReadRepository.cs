using LearningManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace LearningManagementSystem.Infrastructure.Persistence.Repositories
{
    public class UserReadRepository    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserReadRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

     
    }
}
