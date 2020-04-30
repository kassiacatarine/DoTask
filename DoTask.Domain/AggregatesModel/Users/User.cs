using DoTask.Domain.AggregatesModel.Tasks;
using DoTask.Domain.SeedWork;
using System.Collections.Generic;

namespace DoTask.Domain.AggregatesModel.Users
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public List<Task> Tasks { get; private set; }

        protected User() { }

        public User(
            string name,
            string email,
            string password
        ) : this()
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
