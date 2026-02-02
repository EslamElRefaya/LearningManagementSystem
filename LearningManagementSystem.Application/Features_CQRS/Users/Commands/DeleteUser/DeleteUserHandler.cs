using LearningManagementSystem.Domain.Interfaces.Repositories;
using LearningManagementSystem.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LearningManagementSystem.Application.Features_CQRS.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteUserHandler(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var user = await _unitOfWork.Users.GetUserById(request.UserId)
                    ?? throw new KeyNotFoundException("User not found");

                user.SoftDelete();
                await _unitOfWork.Users.SoftDeleteUserAsync(user);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

                return Unit.Value;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

    }
}
