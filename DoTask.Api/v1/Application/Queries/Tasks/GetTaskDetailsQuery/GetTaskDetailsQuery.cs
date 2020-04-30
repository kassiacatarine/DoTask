using DoTask.Api.v1.Application.Queries.Tasks.GetTaskDetailsQuery.ViewModels;
using MediatR;

namespace DoTask.Api.v1.Application.Queries.Tasks.GetTaskDetailsQuery
{
    public class GetTaskDetailsQuery : IRequest<TaskDetails>
    {
        public int Id { get; set; }
        public GetTaskDetailsQuery(int id)
        {
            Id = id;
        }
    }
}
