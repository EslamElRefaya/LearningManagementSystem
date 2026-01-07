using LearningManagementSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Instractors.Commands.DeleteInstractor
{
    public class DeleteInstractorHandler : IRequestHandler<DeleteInstractorCommand, Unit>
    {
        private readonly IInstractorRepository _instractorRepository;

        public DeleteInstractorHandler(IInstractorRepository instractorRepository)
        {
            _instractorRepository = instractorRepository;
        }
        public async Task<Unit> Handle(DeleteInstractorCommand request, CancellationToken cancellationToken)
        {
            var instractor = await _instractorRepository.GetByIdAsync(request.instractorId);
         if (instractor == null)
                throw new KeyNotFoundException($"Course with id {request.instractorId} not found");

            await _instractorRepository.DeleteAsync(instractor);
            return Unit.Value;


        }
    }
}
