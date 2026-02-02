using LearningManagementSystem.Application.DTOs.Users;
using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Infrastructure.Identity;
using Mapster;
namespace LearningManagementSystem.Application.Mapping
{
   public static class UserMapping
    {
        public static void Register()
        {
            // Create / Update DTO → Domain
            TypeAdapterConfig<CreateUpdateUserDto, User>.NewConfig();

            // Domain → Details DTO
            TypeAdapterConfig<ApplicationUser, DetailsUserDto>.NewConfig()
               .Map(dest => dest.UserId, src => src.UserId)
               .Map(dest => dest.FullName, src => src.User.FullName)
               .Map(dest => dest.Email, src => src.Email)
               .Map(dest => dest.UserName, src => src.UserName)
               .Map(dest => dest.Phone, src => src.PhoneNumber)
               .Map(dest => dest.Password, src => src.PasswordHash)
               .Ignore(dest => dest.RoleName); // handled in repository
        }
    }
}