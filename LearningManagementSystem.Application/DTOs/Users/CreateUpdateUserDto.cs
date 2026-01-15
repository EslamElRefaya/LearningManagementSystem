namespace LearningManagementSystem.Application.DTOs.Users
{
  public class CreateUpdateUserDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int Role { get; set; }
    }
}
