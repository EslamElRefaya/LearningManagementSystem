using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration; 
using LearningManagementSystem.Application.Mapping;
using FluentValidation;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

namespace LearningManagementSystem.Application.DependencyInjection
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration) 
        {
            // MediatR
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));

            // Add MailKit Service correctly
            services.AddMailKit(config =>
            {
                config.UseMailKit(configuration.GetSection("Email").Get<MailKitOptions>());
            });

            // Mapster mappings
            CourseMapping.Register();
            InstractorMapping.Register();
            UserMapping.Register();

            // FluentValidation (Validators)
            services.AddValidatorsFromAssembly(typeof(ApplicationServiceRegistration).Assembly);

            return services;
        }
    }
}
