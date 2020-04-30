using DoTask.Domain.AggregatesModel.Users;
using DoTask.Domain.SeedWork;
using DoTask.Infrastructure.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DoTask.Api.v1.Application.Commands.Users.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Response>
    {
        private readonly IUserRepository _userRepository;
        public LoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Response> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var userToLogin = await _userRepository.FindByEmailAsync(request.Email);
            if (userToLogin == null)
                return new Response().AddError("Email not found");
            if (userToLogin.Password != request.Password)
                return new Response().AddError("Email not found");

            var token = TokenService.GenerateToken(userToLogin);
            return new Response(new
            {
                User = new
                {
                    Name = userToLogin.Name,
                    Email = userToLogin.Email
                },
                Token = token
            });
        }
    }
}
