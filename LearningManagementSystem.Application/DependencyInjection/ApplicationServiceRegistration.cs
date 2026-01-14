using Microsoft.Extensions.DependencyInjection;
using LearningManagementSystem.Application.Mapping;

namespace LearningManagementSystem.Application.DependencyInjection
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            // Mapster
            CourseMapping.Register();
            InstractorMapping.Register();
            UserMapping.Register();

            return services;
        }
    }
}
