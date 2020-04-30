using DoTask.Domain.SeedWork;

namespace DoTask.Domain.AggregatesModel.Tasks
{
    public class Task : Entity, IAggregateRoot
    {
        public string Description { get; private set; }
        public bool Concluded { get; private set; }
        public int UserId { get; private set; }

        protected Task() { }

        public Task(
            int id,
            string description,
            int userId
        ) : this()
        {
            Id = id;
            Description = description;
            Concluded = false;
            UserId = userId;
        }
    }
}
