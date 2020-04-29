using System;

namespace DoTask.Domain.AggregatesModel.Tasks
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
