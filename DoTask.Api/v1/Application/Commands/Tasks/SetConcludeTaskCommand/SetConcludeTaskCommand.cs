using DoTask.Domain.SeedWork;
using MediatR;

namespace DoTask.Api.v1.Application.Commands.Tasks.SetConcludeTaskCommand
{
    public class SetConcludeTaskCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
