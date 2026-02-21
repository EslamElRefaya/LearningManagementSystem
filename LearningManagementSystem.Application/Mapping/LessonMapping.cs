using LearningManagementSystem.Application.DTOs.Lessons;
using LearningManagementSystem.Domain.Entities;
using Mapster;

namespace LearningManagementSystem.Application.Mapping
{
   public static class LessonMapping
    {
        public static void Register()
        {
            TypeAdapterConfig<CreateLessonDto, Lesson>.NewConfig();
            TypeAdapterConfig<UpdateLessonDto, Lesson>.NewConfig()
                .Ignore(dest => dest.Id);
            TypeAdapterConfig<Lesson, DetailsLessonDto>.NewConfig()
                .Map(dest=>dest.LessonId, src => src.Id)
                .Map(dest => dest.CourseName, src => src.Course.Title);
        }
    }
}
