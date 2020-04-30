namespace DoTask.Api.v1.Application.Queries.Tasks.GetTaskDetailsQuery.ViewModels
{
    public class TaskDetails
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Concluded { get; set; }
    }
}
