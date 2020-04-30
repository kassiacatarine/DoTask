using DoTask.Domain.SeedWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DoTask.Api.v1.Application.Commands.Users.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Response>
    {
        public Task<Response> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
