using LearningManagementSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Instractors.Commands.UpdateInstractor
{
    public class UpdateInstractorHandler : IRequestHandler<UpdateInstractorCommand, Unit>
    {
        private readonly IInstractorRepository _instractorRepository;

        public UpdateInstractorHandler(IInstractorRepository instractorRepository)
        {
            _instractorRepository = instractorRepository;
        }
        public async Task<Unit> Handle(UpdateInstractorCommand request, CancellationToken cancellationToken)
        {
            if(request.createAndUpdateInstractorDto == null)
                throw new ArgumentException("Instractor data is required");

            var instractor = await _instractorRepository.GetByIdAsync(request.instractorId);
            if (instractor == null)
                throw new KeyNotFoundException($"Instractor with id {request.instractorId} not found");
            
            instractor.FullName = request.createAndUpdateInstractorDto.FullName;
            instractor.Degree = request.createAndUpdateInstractorDto.Degree;
            instractor.Certificates = request.createAndUpdateInstractorDto.Certificates;
            instractor.Bio = request.createAndUpdateInstractorDto.Bio;

            return Unit.Value;
        }
    }
}
