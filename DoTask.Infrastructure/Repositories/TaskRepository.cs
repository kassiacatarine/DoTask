using Dapper;
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
        private readonly CommandsDbContext _commandsContext;
        private readonly QueriesDbContext _queriesContext;
        public IUnitOfWork UnitOfWork => _commandsContext;

        public TaskRepository(CommandsDbContext commandsContext, QueriesDbContext queriesContext)
        {
            _commandsContext = commandsContext ?? throw new ArgumentNullException(nameof(commandsContext));
            _queriesContext = queriesContext ?? throw new ArgumentNullException(nameof(queriesContext));
        }


        public Domain.AggregatesModel.Tasks.Task Add(Domain.AggregatesModel.Tasks.Task task)
        {
            return _commandsContext.Tasks.Add(task).Entity;
        }

        public async Task<Domain.AggregatesModel.Tasks.Task> FindByIdAsync(int id)
        {
            return await _commandsContext.Tasks
                .Where(t => t.Id == id)
                .SingleOrDefaultAsync();
        }

        public void Update(Domain.AggregatesModel.Tasks.Task task)
        {
            _commandsContext.Entry(task).State = EntityState.Modified;
        }

        public async Task<TViewModel[]> ListTaskSummaryAsync<TViewModel>()
        {
            var sql = @"
                select t.id, t.description, t.concluded, t.removed
                from dbo.tasks t";

            using (var connection = _queriesContext.Database.GetDbConnection())
            {
                var tasks = await connection.QueryAsync<TViewModel>(sql);
                return tasks.ToArray();
            }
        }

        public async System.Threading.Tasks.Task<TViewModel> GetTaskDetailsAsync<TViewModel>(int id)
        {
            var sql = @"
                select t.id, t.description, t.concluded
                from dbo.tasks t
                where t.id = @Id";

            using (var connection = _queriesContext.Database.GetDbConnection())
            {
                var taskDetails = await connection.QueryFirstOrDefaultAsync<TViewModel>(sql, new { Id = id });
                return taskDetails;
            }
        }
    }
}
