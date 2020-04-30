using DoTask.Domain.AggregatesModel.Tasks;
using DoTask.Domain.SeedWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DoTask.Api.v1.Application.Commands.Tasks.CreateTaskCommand
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Response>
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// Handler which processes the command when
        /// customer executes cancel order from app
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<Response> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var newTask = new Domain.AggregatesModel.Tasks.Task(
                id: request.Id,
                description: request.Description,
                userId: request.UserId);

            var result = await _taskRepository.UnitOfWork
                .SaveChangesAsync(cancellationToken);

            if (result == 0)
                return new Response().AddError("Task insertion error");

            return new Response("Successful task insertion");
        }
    }
}
