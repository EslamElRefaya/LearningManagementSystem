using LearningManagementSystem.Api.Extensions;
using LearningManagementSystem.Api.Middlewares;
using LearningManagementSystem.Application.DependencyInjection;
using LearningManagementSystem.Infrastructure.Authentication;
using LearningManagementSystem.Infrastructure.DependencyInjection;

// this P-->> 1
var builder = WebApplication.CreateBuilder(args);

#region 2==> Add Framework Services.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenAuthentication();
#endregion

#region Layer Services
builder.Services
            .AddApplicationServices(builder.Configuration)
            .AddInfrastructureServices(builder.Configuration)
            .AddCorsPolicy();
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

//Global Exception Middleware
app.UseMiddleware<GlobalExceptionMiddleware>();

// this P-->> 4
app.UseAuthentication();

// this P-->> 5
app.UseAuthorization();

// this P-->> 6
app.MapControllers();

// this P-->> 7
//this close middleware
app.Run();

