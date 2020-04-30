using DoTask.Domain.AggregatesModel.Tasks;
using DoTask.Domain.SeedWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DoTask.Api.v1.Application.Commands.Tasks.UpdateTaskCommand
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Response>
    {
        private readonly ITaskRepository _taskRepository;
        public UpdateTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<Response> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var oldTask = await _taskRepository.FindByIdAsync(request.Id);
            if (oldTask == null)
            {
                return new Response().AddError("Task with id not found");
            }
            oldTask.Update(request.Description);

            _taskRepository.Update(oldTask);

            var result = await _taskRepository.UnitOfWork
                .SaveChangesAsync(cancellationToken);

            if (result == 0)
                return new Response().AddError("Task update error");

            return new Response("Successful task update");
        }
    }
}
