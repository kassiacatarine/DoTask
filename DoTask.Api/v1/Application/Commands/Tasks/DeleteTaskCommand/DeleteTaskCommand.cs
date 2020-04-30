using DoTask.Domain.SeedWork;
using MediatR;

namespace DoTask.Api.v1.Commands.Tasks.DeleteTaskCommand
{
    public class DeleteTaskCommand : IRequest<Response>
    {
    }
}
