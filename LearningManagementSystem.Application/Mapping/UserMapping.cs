using LearningManagementSystem.Application.DTOs.Users;
using LearningManagementSystem.Domain.Entities;
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
            TypeAdapterConfig<User, DetailsUserDto>.NewConfig()
                .Map(dest => dest.UserId, src => src.Id);
        }
    }
}
