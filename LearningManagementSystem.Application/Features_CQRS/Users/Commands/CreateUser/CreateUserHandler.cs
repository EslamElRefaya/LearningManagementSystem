using LearningManagementSystem.Domain.Interfaces.Repositories;
using MediatR;
namespace LearningManagementSystem.Application.Features_CQRS.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Guid> Handle(CreateUserCommand request,CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var user = await _unitOfWork.Users.CreateUserAsync(
                    request.FullName,
                    request.Email,
                    request.UserName,
                    request.Password,
                    request.Phone);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

                return user.Id;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}

