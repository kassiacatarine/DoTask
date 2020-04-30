using DoTask.Domain.AggregatesModel.Tasks;
using DoTask.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoTask.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly CommandsDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public TaskRepository(CommandsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public Domain.AggregatesModel.Tasks.Task Add(Domain.AggregatesModel.Tasks.Task task)
        {
            return _context.Tasks.Add(task).Entity;
        }

        public async Task<Domain.AggregatesModel.Tasks.Task> FindByIdAsync(int id)
        {
            return await _context.Tasks
                .Where(t => t.Id == id)
                .SingleOrDefaultAsync();
        }

        public void Update(Domain.AggregatesModel.Tasks.Task task)
        {
            _context.Entry(task).State = EntityState.Modified;
        }
    }
}
