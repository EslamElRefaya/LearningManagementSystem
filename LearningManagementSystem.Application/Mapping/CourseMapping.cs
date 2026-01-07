using LearningManagementSystem.Domain.Entities;
using Mapster;
namespace LearningManagementSystem.Application.Mapping
{
    public static class CourseMapping
    {
        public static void Register()
        {
            TypeAdapterConfig<Course, DetailsCourseDto>
                .NewConfig()
                .Map(dest => dest.Price, src => src.CoursePrice.Amount)
                 .Map(dest => dest.Currency, src => src.CoursePrice.Currency)
                 .Map(dest => dest.StatusPublishing, src => src.Status)
                .Map(dest => dest.CourseId, src => src.Id)
                .Map(opt => opt.InstractorName, src => src.Instractor.FullName);
        }
    }
}
