using DoTask.Domain.AggregatesModel.Users;
using DoTask.Domain.SeedWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DoTask.Api.v1.Application.Commands.Users.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.FindByEmailAsync(request.Email) != null)
            {
                return new Response().AddError("Email already registered");
            }
            var user = new User(
                    name: request.Name,
                    email: request.Email,
                    password: request.Password
                );

            _userRepository.Add(user);

            var result = await _userRepository.UnitOfWork
                .SaveChangesAsync(cancellationToken);

            if (result == 0)
                return new Response().AddError("User insertion error");

            return new Response("Successful user insertion");
        }
    }
}
