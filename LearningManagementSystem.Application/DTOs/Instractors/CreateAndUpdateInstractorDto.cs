using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Application.DTOs.Instractors
{
    public class CreateAndUpdateInstractorDto
    {
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;
        [MaxLength(300)]
        public string Degree { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Certificates { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Bio { get; set; } = string.Empty;

    }
}
