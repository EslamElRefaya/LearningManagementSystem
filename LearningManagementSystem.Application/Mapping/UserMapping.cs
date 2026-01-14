using LearningManagementSystem.Application.DTOs.Users;
using LearningManagementSystem.Domain.Entities;
using Mapster;

namespace LearningManagementSystem.Application.Mapping
{
   public static class UserMapping
    {
        public static void Register()
        {
            TypeAdapterConfig<User, DetailsUserDto>
                .NewConfig()
                .Map(dest => dest.UserId, src => src.Id)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Role, src => src.Role);
        }
    }
}
