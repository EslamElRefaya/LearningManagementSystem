using System.ComponentModel.DataAnnotations;
using LearningManagementSystem.Domain.Common;
using LearningManagementSystem.Domain.Enums;
using LearningManagementSystem.Domain.ValueObjects;
namespace LearningManagementSystem.Domain.Entities
{
    public class User : AuditableEntity
    {
        [MaxLength(200)]
        public string FullName { get; set; } = string.Empty;
        public Email Email { get; private set; } = null!;
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
        [MaxLength(100)]
        public string UserName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Phone { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Student;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Submission> Submissions { get; set; } = new List<Submission>();
        //initial contractor
        private User() { }
        public static User Create(string fullName, string email, string password, string userName, string phone, UserRole role)
        {
            var user = new User
            {
                FullName = fullName,
                Password = password,
                UserName = userName,
                Phone = phone,
                Role = role
            };

            user.SetEmail(email); // Email private
            return user;
        }

        public void SetEmail(string email)
        {
            Email = new Email(email);
        }

        // Only Email update method because Email is Value Object(private set in property)
        public void UpdateEmail(Email email)
        {
            if (email == null)
                throw new ArgumentException("Email is required");
            Email = email;
        }
    }
}
