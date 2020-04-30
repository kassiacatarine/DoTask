using Dapper;
using DoTask.Domain.AggregatesModel.Users;
using DoTask.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoTask.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CommandsDbContext _commandsContext;
        private readonly QueriesDbContext _queriesContext;
        public IUnitOfWork UnitOfWork => _commandsContext;

        public UserRepository(CommandsDbContext commandsContext, QueriesDbContext queriesContext)
        {
            _commandsContext = commandsContext ?? throw new ArgumentNullException(nameof(commandsContext));
            _queriesContext = queriesContext ?? throw new ArgumentNullException(nameof(queriesContext));
        }


        public User Add(User user)
        {
            return _commandsContext.Users.Add(user).Entity;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _commandsContext.Users
                .Where(u => u.Email == email)
                .SingleOrDefaultAsync();
        }

        public void Update(User user)
        {
            _commandsContext.Entry(user).State = EntityState.Modified;
        }

        public async Task<IEnumerable<T>> ListUserSummaryAsync<T>()
        {
            var sql = @"
                select u.id, u.name, u.email, u.removed
                from dbo.users u";

            using (var connection = _queriesContext.Database.GetDbConnection())
            {
                var users = await connection.QueryAsync<T>(sql);
                return users;
            }
        }
    }
}
