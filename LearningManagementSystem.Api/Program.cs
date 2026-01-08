using LearningManagementSystem.Application.Features_CQRS.Courses.Commands.CreateCourse;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using LearningManagementSystem.Infrastructure.Persistence;
using LearningManagementSystem.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using LearningManagementSystem.Application.Mapping;
using LearningManagementSystem.Application.Features_CQRS.Instractors.Commands.CreateInstractor;
using LearningManagementSystem.Application.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        #region  4-- Add connection string or Add 'DbContext'
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));
        #endregion

        builder.Services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(
                typeof(Program).Assembly,
                typeof(CreateCourseHandler).Assembly
                //typeof(CreateInstractorHandler).Assembly
                );
        });
        #region  resgistr Mapster
        builder.Services.AddApplicationServices();
        #endregion
        #region Add Inject Repository 
        builder.Services.AddScoped<ICourseRepository, CourseRepository>();
        builder.Services.AddScoped<IInstractorRepository, InstractorRepository>();
        #endregion
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}



