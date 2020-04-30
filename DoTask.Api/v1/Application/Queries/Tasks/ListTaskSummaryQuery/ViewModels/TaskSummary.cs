namespace DoTask.Api.v1.Application.Queries.Tasks.ListTaskSummaryQuery.ViewModels
{
    public class TaskSummary
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Concluded { get; set; }
        public bool Removed { get; set; }
    }
}
