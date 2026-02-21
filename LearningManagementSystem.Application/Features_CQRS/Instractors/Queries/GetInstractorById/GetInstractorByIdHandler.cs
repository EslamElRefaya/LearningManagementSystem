using LearningManagementSystem.Application.DTOs.Instractors;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Instractors.Queries.GetInstractorById
{
    public class GetInstractorByIdHandler : IRequestHandler<GetInstractorByIdQuery, DetailsInstractorDto>
    {
        private readonly IInstractorRepository _instractorRepository;

        public GetInstractorByIdHandler(IInstractorRepository instractorRepository)
        {
            _instractorRepository = instractorRepository;
        }

        public async Task<DetailsInstractorDto> Handle(GetInstractorByIdQuery request, CancellationToken cancellationToken)
        {
            var instractor = await _instractorRepository.GetByIdAsync(request.InstractorId);
            if (instractor == null)
                throw new KeyNotFoundException("Instructor not found");

            return instractor.Adapt<DetailsInstractorDto>();
        }
    }
}
