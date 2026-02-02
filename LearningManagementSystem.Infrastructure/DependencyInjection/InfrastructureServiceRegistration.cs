using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using LearningManagementSystem.Infrastructure.Persistence;
using LearningManagementSystem.Infrastructure.Persistence.Repositories;
using LearningManagementSystem.Domain.Interfaces;
using LearningManagementSystem.Infrastructure.Authentication;
using LearningManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace LearningManagementSystem.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, IConfiguration configuration)
        {
        
            #region  Add connection string or Add 'DbContext'
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(option =>
                                        option.UseSqlServer(connectionString));
            #endregion

            #region Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>()
                   .AddDefaultTokenProviders();
            #endregion

            #region JWT
            services.AddJWTAuthentication(configuration);
            services.AddScoped<JwtTokenService>();

            #endregion

            #region Repositories
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IInstractorRepository, InstractorRepository>();
            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            return services;
        }
    }
}
