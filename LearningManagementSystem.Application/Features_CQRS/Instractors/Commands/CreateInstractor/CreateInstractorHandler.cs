using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Instractors.Commands.CreateInstractor
{
    public class CreateInstractorHandler : IRequestHandler<CreateInstractorCommand, Guid>
    {
        private readonly IInstractorRepository _instractorRepository;

        public CreateInstractorHandler(IInstractorRepository instractorRepository)
        {
            _instractorRepository = instractorRepository;
        }

        public async Task<Guid> Handle(CreateInstractorCommand request, CancellationToken cancellationToken)
        {
            var dto=request.createAndUpdateInstractorDto;
            var instractor = new Instractor
            { 
                FullName=dto.FullName,
                Degree=dto.Degree,
                Certificates =dto.Certificates,
                Bio=dto.Bio,
            };
            await _instractorRepository.AddAsync(instractor);
            return instractor.Id;
        }
    }
}
