using DoTask.Domain.AggregatesModel.Tasks;
using DoTask.Domain.SeedWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DoTask.Api.v1.Application.Commands.Tasks.DeleteTaskCommand
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Response>
    {
        private readonly ITaskRepository _taskRepository;
        public DeleteTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<Response> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskToDelete = await _taskRepository.FindByIdAsync(request.Id);
            if (taskToDelete == null)
            {
                return new Response().AddError("Task with id not found");
            }
            taskToDelete.Remove();

            _taskRepository.Update(taskToDelete);

            var result = await _taskRepository.UnitOfWork
                .SaveChangesAsync(cancellationToken);

            if (result == 0)
                return new Response().AddError("Task delete error");

            return new Response("Successful task delete");
        }
    }
}
