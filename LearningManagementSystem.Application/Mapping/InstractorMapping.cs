using LearningManagementSystem.Application.DTOs.Instractors;
using LearningManagementSystem.Domain.Entities;
using Mapster;

namespace LearningManagementSystem.Application.Mapping
{
    public static class InstractorMapping
    {
        public static void Register()
        {
            TypeAdapterConfig<Instractor, DetailsInstractorDto>
                .NewConfig()
            .Map(opt=>opt.InstractorId,src=>src.Id);
            TypeAdapterConfig<CreateAndUpdateInstractorDto, Instractor>
            .NewConfig();
        }
    }
}
