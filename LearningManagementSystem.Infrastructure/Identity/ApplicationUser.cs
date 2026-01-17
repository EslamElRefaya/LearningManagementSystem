using LearningManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace LearningManagementSystem.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public Guid UserId { get; set; } // FK → User
        public User User { get; set; }=default!;
    }
}
