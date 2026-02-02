using LearningManagementSystem.Application.DTOs.Accounts;
using LearningManagementSystem.Application.DTOs.Users;
using LearningManagementSystem.Domain.Entities;
using Mapster;

namespace LearningManagementSystem.Application.Mapping
{
   public static class AcountMapping
    {
        public static void Register()
        {
            // Domain → Details DTO
            TypeAdapterConfig<User, DetailsRegistrationDto>.NewConfig();
        }
    }
}
