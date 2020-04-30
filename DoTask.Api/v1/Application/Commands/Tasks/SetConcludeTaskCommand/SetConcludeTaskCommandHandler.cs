using DoTask.Domain.AggregatesModel.Tasks;
using DoTask.Domain.SeedWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DoTask.Api.v1.Application.Commands.Tasks.SetConcludeTaskCommand
{
    public class SetConcludeTaskCommandHandler : IRequestHandler<SetConcludeTaskCommand, Response>
    {
        private readonly ITaskRepository _taskRepository;
        public SetConcludeTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<Response> Handle(SetConcludeTaskCommand request, CancellationToken cancellationToken)
        {
            var taskToUpdate = await _taskRepository.FindByIdAsync(request.Id);
            if (taskToUpdate == null)
            {
                return new Response().AddError("Task with id not found");
            }

            taskToUpdate.SetConcluded();
            var result = await _taskRepository
                .UnitOfWork
                .SaveChangesAsync(cancellationToken);

            if (result == 0)
                return new Response().AddError("Error when setting to complete the task");

            return new Response("successfully completed task set");
        }
    }
}
