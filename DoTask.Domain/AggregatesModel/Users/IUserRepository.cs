using DoTask.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoTask.Domain.AggregatesModel.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User Add(User user);
        void Update(User user);
        Task<User> FindByEmailAsync(string email);
        Task<IEnumerable<T>> ListUserSummaryAsync<T>();
    }
}
