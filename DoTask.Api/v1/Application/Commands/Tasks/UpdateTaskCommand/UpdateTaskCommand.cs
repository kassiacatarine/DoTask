using DoTask.Domain.SeedWork;
using MediatR;

namespace DoTask.Api.v1.Application.Commands.Tasks.UpdateTaskCommand
{
    public class UpdateTaskCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
