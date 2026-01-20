using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace LearningManagementSystem.Infrastructure.Authentication
{
    public static class CustomJWTAuthentication
    {
        //this is Extension Method
        public static void AddJWTAuthentication(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuthentication(option =>
            {
                //this find JwtBearer
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                // this make to work Authentication Directly After login
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(option =>
             {
                 option.RequireHttpsMetadata = false; //make work at Https and Anouther
                 option.SaveToken = true;
                 // check on Validation parameters this is in Program.cs
                 option.TokenValidationParameters = new TokenValidationParameters()
                 {
                     /*
                      if set ValidateIssuer ==false , we must not enter Issuer value
                            ==>> this use in microservices (multi api)
                     and this == in ValidateAudience
                    */
                     ValidateIssuer = true,
                     ValidIssuer = configuration["JWT:Issuer"],

                     
                     ValidateAudience = false,
                     //ValidateAudience = true,
                     //ValidAudience = configuration["JWT:Audience"],

                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]))

                 };

             });
        }

        public static void AddSwaggerGenAuthentication(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "LMS API",
                    Description = "JWT Authentication API"
                });

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter JWT Token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    }, new List<string>()
                }
            });
            });
        }
    }
}
