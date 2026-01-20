using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagementSystem.Application.Interfaces;
using LearningManagementSystem.Infrastructure.Authentication;
using MediatR;

namespace LearningManagementSystem.Application.Features_CQRS.Users.Commands.Login
{

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenService _jwtService;

        public LoginUserCommandHandler(IUserRepository userRepository,
                                       JwtTokenService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // 1 check username and password
            bool valid = await _userRepository.CheckPasswordAsync(request.UserName, request.Password);
            if (!valid)
                throw new Exception("Invalid username or password");

            // 2 generate JWT token
            var token = await _jwtService.GenerateToken(request.UserName);

            return token;
        }
    }
}
