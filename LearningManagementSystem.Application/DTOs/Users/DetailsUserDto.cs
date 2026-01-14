using LearningManagementSystem.Domain.Enums;

namespace LearningManagementSystem.Application.DTOs.Users
{
   public class DetailsUserDto
    {
        public string UserId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; private set; } = null!;
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Role { get; set; }=string.Empty;
    }
}
