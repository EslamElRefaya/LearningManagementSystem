using LearningManagementSystem.Application.DTOs.Users;
using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Enums;
using LearningManagementSystem.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, DetailsUserDto>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DetailsUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // ✅ استخدم الاسم الصحيح من Command
            var dto = request.createUserDto;

            // 1️⃣ إنشاء User (بدون constructor مباشر)
            var user = User.Create(
                fullName: dto.FullName,
                email: dto.Email,
                password: dto.Password,
                userName: dto.UserName,
                phone: dto.Phone,
                role: (UserRole)dto.Role
            );

            // 2️⃣ حفظ في Repository
            await _userRepository.AddAsync(user);

            // 3️⃣ تحويل Domain → DTO باستخدام Mapster
            var userDto = user.Adapt<DetailsUserDto>();

            return userDto;
        }
    }
}
