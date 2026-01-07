namespace LearningManagementSystem.Application.DTOs.Instractors
{
    public class DetailsInstractorDto
    {

        public Guid InstractorId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Degree { get; set; } = string.Empty;
        public string Certificates { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;

    }
}
