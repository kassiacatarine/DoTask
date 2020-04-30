using DoTask.Domain.SeedWork;

namespace DoTask.Domain.AggregatesModel.Tasks
{
    public interface ITaskRepository : IRepository<Task>
    {
        Task Add(Task task);

        void Update(Task task);

        System.Threading.Tasks.Task<Task> FindByIdAsync(int id);
    }
}
