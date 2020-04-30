using DoTask.Api.v1.Application.Queries.Tasks.ListTaskSummaryQuery.ViewModels;
using DoTask.Domain.AggregatesModel.Tasks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DoTask.Api.v1.Application.Queries.Tasks.ListTaskSummaryQuery
{
    public class ListTaskSummaryQueryHandler : IRequestHandler<ListTaskSummaryQuery, TaskSummary[]>
    {
        private readonly ITaskRepository _taskRepository;
        public ListTaskSummaryQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<TaskSummary[]> Handle(ListTaskSummaryQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.ListTaskSummaryAsync<TaskSummary>();
            return tasks;
        }
    }
}
