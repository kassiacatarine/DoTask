using DoTask.Domain.AggregatesModel.Users;
using DoTask.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DoTask.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DoTaskCommandsDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public UserRepository(DoTaskCommandsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public User Add(User user)
        {
            return _context.Users.Add(user).Entity;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Users
                .Where(u => u.Email == email)
                .SingleOrDefaultAsync();
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
