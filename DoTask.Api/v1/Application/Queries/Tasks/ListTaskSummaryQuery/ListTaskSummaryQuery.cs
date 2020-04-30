using DoTask.Api.v1.Application.Queries.Tasks.ListTaskSummaryQuery.ViewModels;
using MediatR;

namespace DoTask.Api.v1.Application.Queries.Tasks.ListTaskSummaryQuery
{
    public class ListTaskSummaryQuery : IRequest<TaskSummary[]>
    {
    }
}
