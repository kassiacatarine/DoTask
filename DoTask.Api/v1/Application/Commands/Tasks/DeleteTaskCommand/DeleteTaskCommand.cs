using DoTask.Domain.SeedWork;
using MediatR;

namespace DoTask.Api.v1.Application.Commands.Tasks.DeleteTaskCommand
{
    public class DeleteTaskCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
