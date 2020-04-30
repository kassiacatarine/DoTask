using DoTask.Domain.SeedWork;
using MediatR;

namespace DoTask.Api.v1.Application.Commands.Users.LoginCommand
{
    public class LoginCommand : IRequest<Response>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
