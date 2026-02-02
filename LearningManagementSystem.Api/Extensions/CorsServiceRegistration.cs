namespace LearningManagementSystem.Api.Extensions
{
    public static class CorsServiceRegistration
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy.AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowAnyOrigin());
            });
            return services;
        }
    }
}
