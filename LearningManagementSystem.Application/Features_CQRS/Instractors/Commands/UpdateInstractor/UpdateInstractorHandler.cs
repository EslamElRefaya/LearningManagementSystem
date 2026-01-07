using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagementSystem.Application.DTOs.Instractors;
using LearningManagementSystem.Domain.Entities;
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
            var instractor = await _instractorRepository.GetByIdAsync(request.instractorId);

            instractor.FullName = request.createAndUpdateInstractorDto.FullName;
            instractor.Degree = request.createAndUpdateInstractorDto.Degree;
            instractor.Certificates = request.createAndUpdateInstractorDto.Certificates;
            instractor.Bio = request.createAndUpdateInstractorDto.Bio;

            return Unit.Value;
        }
    }
}
