using LearningManagementSystem.Application.DependencyInjection;
using LearningManagementSystem.Application.Features_CQRS.Courses.Commands.CreateCourse;
using LearningManagementSystem.Application.Interfaces;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using LearningManagementSystem.Infrastructure.Authentication;
using LearningManagementSystem.Infrastructure.Identity;
using LearningManagementSystem.Infrastructure.Persistence;
using LearningManagementSystem.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// this P-->> 1
var builder = WebApplication.CreateBuilder(args);

#region 2==> Add Framework Services.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenAuthentication();
#endregion

// this P-->> 3
//Add Configuration & Options

#region  4-- Add connection string or Add 'DbContext'
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));
#endregion

#region 5==> inject userManager and roleManager identity to application
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();
#endregion

#region 6==> add Custom JWT Authentication
builder.Services.AddJWTAuthentication(builder.Configuration);
builder.Services.AddScoped<JwtTokenService>();

#endregion


#region 7==> Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
    policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});
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
builder.Services.AddScoped<IUserRepository, UserRepository>();
#endregion
var app = builder.Build();


// this P-->> 1
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// this P-->> 2
//HTTPS redirection
app.UseHttpsRedirection();

// this P-->> 3
//CORS
app.UseCors("AllowAll");
// this P-->> 4
app.UseAuthentication();

// this P-->> 5
app.UseAuthorization();

// this P-->> 6
app.MapControllers();

// this P-->> 7
//this close middleware
app.Run();

