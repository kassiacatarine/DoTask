using DoTask.Domain.SeedWork;
using MediatR;

namespace DoTask.Api.v1.Application.Commands.Tasks.CreateTaskCommand
{
    public class CreateTaskCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
