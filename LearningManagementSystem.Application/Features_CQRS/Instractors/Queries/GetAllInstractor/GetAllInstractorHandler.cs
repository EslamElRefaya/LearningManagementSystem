using LearningManagementSystem.Application.DTOs.Instractors;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Instractors.Queries.GetAllInstractor
{
    public class GetAllInstractorHandler : IRequestHandler<GetAllInstractorQuery, List<DetailsInstractorDto>>
    {
        private readonly IInstractorRepository _instractorRepository;

        public GetAllInstractorHandler(IInstractorRepository instractorRepository)
        {
            _instractorRepository = instractorRepository;
        }

        public async Task<List<DetailsInstractorDto>> Handle(GetAllInstractorQuery request, CancellationToken cancellationToken)
        {
            var instractors = await _instractorRepository.GetAllAsync();

            return instractors.Adapt<List<DetailsInstractorDto>>();
        }
    }
}
