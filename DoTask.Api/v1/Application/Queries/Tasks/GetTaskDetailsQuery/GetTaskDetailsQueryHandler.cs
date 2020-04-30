using DoTask.Api.v1.Application.Queries.Tasks.GetTaskDetailsQuery.ViewModels;
using DoTask.Domain.AggregatesModel.Tasks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DoTask.Api.v1.Application.Queries.Tasks.GetTaskDetailsQuery
{
    public class GetTaskDetailsQueryHandler : IRequestHandler<GetTaskDetailsQuery, TaskDetails>
    {
        private readonly ITaskRepository _taskRepository;
        public GetTaskDetailsQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<TaskDetails> Handle(GetTaskDetailsQuery request, CancellationToken cancellationToken)
        {
            var taskDetails = await _taskRepository.GetTaskDetailsAsync<TaskDetails>(request.Id);
            return taskDetails;
        }
    }
}
