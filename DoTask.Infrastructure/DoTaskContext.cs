using DoTask.Domain.AggregatesModel.Tasks;
using DoTask.Domain.AggregatesModel.Users;
using Microsoft.EntityFrameworkCore;

namespace DoTask.Infrastructure
{
    public class DoTaskContext : DbContext
    {
        public DoTaskContext(DbContextOptions<DoTaskContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
